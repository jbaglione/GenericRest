using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRest.Models
{
    public class RequestAmericaGis
    {
        ///contiene el dominio con el que está registrado el vehículo en AmericaGis
        public string licensePlate { get; set; } //"EZW489"
        public string vehicleBrand { get; set; }//"Fiat"
        public string vehicleModel { get; set; }//"Uno"
        public string driver { get; set; }//"Diaz, Nicolas"
        public string reportDate { get; set; }//"2019-06-12 09:23:28",
        public int eventId { get; set; }//8,
        public string eventName { get; set; }//"Centinela",
        public double latitude { get; set; }//-32.403200,
        public double longitude { get; set; }//-63.242250,
        public decimal speed { get; set; }//0,
        public int course { get; set; }//161,
        public string address { get; set; }//"Salta y Boulevar España",
        public string city { get; set; }//"Villa María",
        public string province { get; set; }//"Córdoba"

        // {
        //    "licensePlate":"EZW489",
        //     "vehicleBrand":"Fiat",
        //     "vehicleModel":"Uno",
        //     "driver":"Diaz, Nicolas",
        //     "reportDate":"2019-06-12 09:23:28",
        //     "eventId":8,
        //     "eventName":"Centinela",
        //     "latitude":-32.403200,
        //     "longitude":-63.242250,
        //     "speed":0,
        //     "course":161,
        //     "address":"Salta y Boulevar España",
        //      "city":"Villa María",
        //     "province":"Córdoba"
        //}
        //licensePlate: contiene el dominio con el que está registrado el vehículo en AmericaGis
        //vehicleBrand: marca del vehículo
        //vehicleModel: modelo del vehículo
        //driver: chofer que posee asignado el vehículo al momento de enviar el reporte
        //reportDate: fecha en que el vehículo generó el reporte
        //eventId: valor constante que identifica el ID del evento en el sistema de AmericaGis
        //eventName: valor constante que identifica el nombre del evento en el sistema de AmericaGis
        //latitude: latitud del reporte
        //longitude: longitud del reporte
        //speed: velocidad en el momento que se generó el reporte
        //course: orientación cardinal del vehículo, expresado en grados
        //address: dirección georeferenciada
        //city: ciudad georeferenciada
        //province: provincia georeferenciada
    }
}