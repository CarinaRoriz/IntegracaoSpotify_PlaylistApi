using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoSpotify_PlaylistApi.Modelos
{
    public class Iten
    {
        public DateTime added_at { get; set; }
        public bool is_local { get; set; }
        public object primary_color { get; set; }
        public Music track { get; set; }
        public VideoThumbnail video_thumbnail { get; set; }
    }
}
