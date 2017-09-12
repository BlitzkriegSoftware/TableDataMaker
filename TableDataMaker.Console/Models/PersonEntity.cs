using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataMaker.ConsoleApp.Models
{
    public class PersonEntity : TableEntity
    {
        public PersonEntity() { }

        public PersonEntity(Guid id)
        {
            var segs = id.ToString().Split(new char[] { '-' });
            this.PartitionKey = segs[0];
            this.RowKey = id.ToString();
            this.Id = id;
        }

        /// <summary>
        /// Row Key (PK)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name Last
        /// </summary>
        public string NameLast { get; set; }
        /// <summary>
        /// Name First
        /// </summary>
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

        /// <summary>
        /// Debugging string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}", 
                    this.Id, 
                    this.NameLast, 
                    this.NameFirst,
                    this.Gender,
                    this.Birthday, 
                    this.Company, 
                    this.EMail, 
                    this.Address1, 
                    this.Address2, 
                    this.City, 
                    this.State, 
                    this.Zip, 
                    this.PartitionKey);
        }
    }
}
