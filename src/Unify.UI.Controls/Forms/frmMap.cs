using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unify.UI.Controls.Classes;

namespace Unify.UI.Controls.Forms
{
    public partial class frmMap : Form
    {
        public EnderecoModel EnderecoSelecionado { get; private set; }
        private readonly EnderecoModel _enderecoInicial;

        public frmMap(EnderecoModel endereco)
        {
            InitializeComponent();
            _enderecoInicial = endereco;
        }

        protected override async void OnLoad(EventArgs e)
        {
            SetLabel(_enderecoInicial);

            await webView21.EnsureCoreWebView2Async();

            webView21.CoreWebView2.WebMessageReceived += WebMessageReceived;

            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "app",
                Application.StartupPath,
                CoreWebView2HostResourceAccessKind.Allow);

            webView21.NavigateToString(GetMapaHtml());
        }

        private async void WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var json = e.WebMessageAsJson;
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            double lat = data.lat;
            double lng = data.lng;

            EnderecoSelecionado = await ReverseGeocodeAsync(lat, lng);
            SetLabel(EnderecoSelecionado);
        }

        private async Task<(double lat, double lng)> GeocodeAsync(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Endereço inválido.");

            var url =
                $"https://nominatim.openstreetmap.org/search" +
                $"?format=jsonv2" +
                $"&q={Uri.EscapeDataString(endereco)}" +
                $"&limit=1";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(
                    "MinhaAplicacaoWinForms/1.0 (contato@seudominio.com)");

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(
                        $"Erro Nominatim: {(int)response.StatusCode} - {error}");
                }

                var json = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                if (result.Count == 0)
                    throw new InvalidOperationException("Endereço não encontrado.");

                return (
                    lat: (double)result[0].lat,
                    lng: (double)result[0].lon
                );
            }
        }


        private async Task<EnderecoModel> ReverseGeocodeAsync(double lat, double lng)
        {
            var url =
                $"https://nominatim.openstreetmap.org/reverse" +
                $"?format=jsonv2" +
                $"&lat={lat.ToString(CultureInfo.InvariantCulture)}" +
                $"&lon={lng.ToString(CultureInfo.InvariantCulture)}" +
                $"&addressdetails=1";

            using (var client = new HttpClient())
            {
                // OBRIGATÓRIO para o Nominatim
                client.DefaultRequestHeaders.UserAgent.ParseAdd(
                    "MinhaAplicacaoWinForms/1.0 (contato@seudominio.com)");

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(
                        $"Erro Nominatim: {(int)response.StatusCode} - {error}");
                }

                var json = await response.Content.ReadAsStringAsync();
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                return new EnderecoModel
                {
                    Rua = data.address.road,
                    Numero = data.address.house_number,
                    Bairro = data.address.suburb,
                    Cidade = data.address.city ?? data.address.town ?? data.address.village,
                    Estado = data.address.state,
                    CEP = data.address.postcode,
                    Latitude = lat,
                    Longitude = lng
                };
            }

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            //var (lat, lng) = await GeocodeAsync(txtEnderecoCompleto.Text);

            //webView2Mapa.CoreWebView2.ExecuteScriptAsync(
            //    $"setLocation({lat.ToString(CultureInfo.InvariantCulture)}, {lng.ToString(CultureInfo.InvariantCulture)})");

            //_enderecoSelecionado = await ReverseGeocodeAsync(lat, lng);
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            if (EnderecoSelecionado == null)
                throw new InvalidOperationException("Nenhum endereço selecionado.");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetLabel(EnderecoModel endereco)
        {
            unifyFrame1.InfoText = $"{endereco.Rua}, {endereco.Numero} - {endereco.Bairro} - {endereco.Cidade} - {endereco.Estado} - {endereco.CEP:#####-###}";
        }

        private string GetMapaHtml()
        {
            return @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <base href='https://app/' />

                    <title>Mapa</title>

                    <link
                        rel='stylesheet'
                        href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css'
                    />

                    <style>
                        html, body, #map {
                            height: 100%;
                            margin: 0;
                        }
                    </style>
                </head>
                <body>

                <div id='map'></div>

                <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>

                <script>
                    let map = L.map('map').setView([-15.78, -47.93], 4);
                    let marker = null;

                    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                        maxZoom: 19,
                        attribution: '© OpenStreetMap'
                    }).addTo(map);

                    function setMarker(lat, lng) {
                        if (marker) map.removeLayer(marker);
                        marker = L.marker([lat, lng]).addTo(map);
                        map.setView([lat, lng], 16);
                    }

                    map.on('click', function (e) {
                        setMarker(e.latlng.lat, e.latlng.lng);
                        chrome.webview.postMessage({
                            lat: e.latlng.lat,
                            lng: e.latlng.lng
                        });
                    });

                    window.setLocation = function (lat, lng) {
                        setMarker(lat, lng);
                    };
                </script>

                </body>
                </html>";
        }


    }
}
