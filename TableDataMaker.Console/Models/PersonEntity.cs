using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TableDataMaker.ConsoleApp.Models
{
    public class PersonEntity : TableEntity
    {
        public PersonEntity() { }

        public PersonEntity(string nameLast, string nameFirst)
        {
            this.PartitionKey = nameLast;
            this.NameLast = PartitionKey;
            this.RowKey = nameFirst;
            this.NameFirst = this.RowKey;
        }

        /// <summary>
        /// Name Last
        /// </summary>
        [JsonIgnore]
        public string NameLast { get; set; }
        /// <summary>
        /// Name First
        /// </summary>
        [JsonIgnore]
        public string NameFirst { get; set; }
        /// <summary>
        /// E-Mail
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(JavaScriptDateTimeConverter))]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Address 1 (Delivery)
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Address 2 (Appt)
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Zip
        /// </summary>
        public string Zip { get; set; }

    }
}
