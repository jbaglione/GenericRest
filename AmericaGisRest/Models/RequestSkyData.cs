using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRest.Models
{
    public class RequestSkyData
    {
        public short code { get; set; }
        public int vid { get; set; }
        public string remote_id { get; set; }
        public string license_plate { get; set; }
        public long device_id { get; set; }
        public string ip { get; set; }
        public short port { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public bool valid_position { get; set; }
        public string event_time { get; set; }//system_time(string)
        public string system_time { get; set; }
        public decimal kmph { get; set; }
        public string placeneme { get; set; }
        //public string poi_ids { get; set; }//string array
        //public string poi_group_ids { get; set; }
        public int[] poi_ids { get; set; }//string array
        public int[] poi_group_ids { get; set; }
        public int alerts_count { get; set; }
        public string route_id { get; set; }
        public int client_id { get; set; }
        public decimal head { get; set; }
        public double odometer { get; set; }
        public double sys_odometer { get; set; }
        public double hourmeter { get; set; }
        public double sys_hourmeter { get; set; }
    }
}
