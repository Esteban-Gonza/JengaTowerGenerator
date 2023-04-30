using UnityEngine;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class APIInformationManager{

    public static APIData GetData(){

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();
        List<APIData> dataList = JsonConvert.DeserializeObject<List<APIData>>(json);
        return dataList[0];
    }
}

[System.Serializable]
public class APIData{

    [JsonProperty("id")]
    public int Id;
    [JsonProperty("subject")]
    public string Subject;
    [JsonProperty("grade")]
    public string Grade;
    [JsonProperty("mastery")]
    public int Mastery;
    [JsonProperty("domainid")]
    public string DomainId;
    [JsonProperty("domain")]
    public string Domain;
    [JsonProperty("cluster")]
    public string Cluster;
    [JsonProperty("standardid")]
    public string StandardId;
    [JsonProperty("standarddescription")]
    public string StandardDescription;
}