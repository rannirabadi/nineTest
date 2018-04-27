using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nine.Models
{
    //create a class for every json object that will be passed in
    //this way, we can just let the Json deserializer handle the entire parse
    class Payload
    {
        [JsonProperty("payload")]
        public List<Show> shows { get; set; }

        //this object will allow us to parse the response neatly
        private struct Response
        {
            [JsonProperty("response")]
            public object shows { get; set; }

        }

        public string response()
        {
            //remove what i don't need
            shows.RemoveAll(s => s.drm == false || s.episodeCount == 0);
            //load the Response object with the 3 attributes
            Response response = new Response() { shows = shows.Select(s => new { s.image.showImage, s.slug, s.title }) };
            return JsonConvert.SerializeObject(response);
        }
    }

    //when the payload is instantiated by the json parse Show will also be instantiated
    //if there are shows passed in the request data
    class Show
    {
        [JsonProperty("county")] public string country;
        [JsonProperty("description")] public string description;
        [JsonProperty("drm")] public bool drm;
        [JsonProperty("episodeCount")] public int episodeCount;
        [JsonProperty("genre")] public string genre;
        [JsonProperty("image")] public Image image;
        [JsonProperty("language")] public string language;
        [JsonProperty("nextEpisode")] public object nextEpisode;
        [JsonProperty("primaryColour")] public string primaryColour;
        [JsonProperty("seasons")] public List<object> seasons;
        [JsonProperty("slug")] public string slug;
        [JsonProperty("title")] public string title;
    }


    //like with Show, Image will be instantiated by the json parse Payload -> Show
    //if there are Images passed in the request data
    class Image
    {
        [JsonProperty("showImage")] public string showImage;
    }
}
