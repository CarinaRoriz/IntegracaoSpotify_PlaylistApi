using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IntegracaoSpotify_PlaylistApi.Modelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntegracaoSpotify_PlaylistApi.Controllers
{
    [Route("v1/playlists")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<ListPlaylist>> GetPorUsuario(string id)
        {
            string token = Request.Headers["Authorization"];

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            UriBuilder builder = new UriBuilder($"https://api.spotify.com/v1/users/{id}/playlists");

            HttpResponseMessage resp = await client.GetAsync(builder.Uri);
            string msg = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListPlaylist>(msg.Replace("\n", ""));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylistPorId(string id)
        {
            string token = Request.Headers["Authorization"];

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage resp = await client.GetAsync($"https://api.spotify.com/v1/playlists/{id}");
            string msg = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Playlist>(msg.Replace("\n", ""));
        }

        [HttpGet("{id}/musicas")]
        public async Task<ActionResult<ListMusic>> GetMusicasPorPlaylist(string id)
        {
            string token = Request.Headers["Authorization"];

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage resp = await client.GetAsync($"https://api.spotify.com/v1/playlists/{id}/tracks");
            string msg = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListMusic>(msg.Replace("\n", ""));
        }
    }
}
