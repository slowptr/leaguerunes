using System.Collections.Generic;
using Newtonsoft.Json;

namespace leaguerunes
{
    public class LeagueRune
    {
        [JsonProperty("current")] public bool Current { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("isActive")] public bool IsActive { get; set; }
        [JsonProperty("isDeletable")] public bool IsDeletable { get; set; } = true;
        [JsonProperty("isEditable")] public bool IsEditable { get; set; } = true;
        [JsonProperty("isValid")] public bool IsValid { get; set; } = true;
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("order")] public int Order { get; set; } = 1;
        [JsonProperty("primaryStyleId")] public int PrimaryStyleId { get; set; }
        [JsonProperty("selectedPerkIds")] public List<int> Runes { get; set; }
        [JsonProperty("subStyleId")] public int SubStyleId { get; set; }
    }
}