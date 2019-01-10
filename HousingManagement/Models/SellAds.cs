using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HousingManagement.Models
{
    public class SellAds
    {
        [Key]
        public Int64 Id { get; set; }
        public string Headline { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string Price { get; set; } 
        public string MainImage { get; set; }
        public int BedroomNo { get; set; }
        public int BathroomNo { get; set; }
        public int OthersNo { get; set; }
        public string NeighborhoodEast { get; set; }
        public string NeighborhoodEastDistance { get; set; }
        public string NeighborhoodWest { get; set; }
        public string NeighborhoodWestDistance { get; set; }
        public string NeighborhoodNorth { get; set; }
        public string NeighborhoodNorthDistance { get; set; }
        public string NeighborhoodSouth { get; set; }
        public string NeighborhoodSouthDistance { get; set; }
        public Int64 AddedBy { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContact { get; set; }
        public string OwnerEmail { get; set; }
    }


    public class SellAdsList
    {
        public List<SellAds> SellAdsAll { get; set; }
    }
}

