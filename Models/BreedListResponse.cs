using System.Collections.Generic;

namespace HUB.Models
{
    public class BreedListResponse
    {
        public Dictionary<string, string[]> Message { get; set; }
        public string Status { get; set; }
    }
}
