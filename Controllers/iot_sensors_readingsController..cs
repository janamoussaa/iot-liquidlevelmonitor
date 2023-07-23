using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using System.Web.Http.Cors;
using UETV.Models;
namespace UETV.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("iot_sensors_readings")]
    public class iot_sensors_readingsController : ApiController
    {
        iotEntities db = new iotEntities();
        [HttpGet]
        [Route("postSensorReading")]
        public IHttpActionResult postSensorReading(int firstSensorId , double firstSensorValue , int secondSensorId , double secondSensorValue)
        {
            APIStatus Status = new APIStatus();
            try
            {
                Status = Bussiness_API_Config.Get_API_Obj("en", "post");
                acc_sensors sens01 = db.acc_sensors.Where(s => s.id == firstSensorId).FirstOrDefault();
                if (sens01 != null)
                {
                    sens01.lastUpdateTime = DateTime.Now.ToString();
                    sens01.lastValue = firstSensorValue;
                    db.Entry(sens01).State = EntityState.Modified;
                    db.SaveChanges();
                    acc_sensor_analytics sensAnalytic01 = new acc_sensor_analytics();
                    sensAnalytic01.sensor_id = firstSensorId;
                    sensAnalytic01.value = firstSensorValue;
                    sensAnalytic01.creationTime = DateTime.Now;
                    db.acc_sensor_analytics.Add(sensAnalytic01);
                    db.SaveChanges();
                }
                acc_sensors sens02 = db.acc_sensors.Where(s => s.id == secondSensorId).FirstOrDefault();
                if (sens02 != null)
                {
                    sens02.lastUpdateTime = DateTime.Now.ToString();
                    sens02.lastValue = secondSensorValue;
                    db.Entry(sens02).State = EntityState.Modified;
                    db.SaveChanges();
                    acc_sensor_analytics sensAnalytic02 = new acc_sensor_analytics();
                    sensAnalytic02.sensor_id = secondSensorId;
                    sensAnalytic02.value = secondSensorValue;
                    sensAnalytic02.creationTime = DateTime.Now;
                    db.acc_sensor_analytics.Add(sensAnalytic02);
                    db.SaveChanges();
                }
                return Ok(new { Status = Status, Response = new { } });
                 }
            catch (Exception E)
            {
                Status = Bussiness_API_Config.Get_API_Obj("en", "ser_err");
                return Ok(new { Status = Status, Response = new { } });
            }

        }
        [HttpGet]
        [Route("getSensorReading")]
        public IHttpActionResult getSensorReading()
        {
            APIStatus Status = new APIStatus();
            try
            {
                Status = Bussiness_API_Config.Get_API_Obj("en", "post");
                List<acc_sensors> sens = db.acc_sensors.ToList();
                List<SensorReadings> data = new List<SensorReadings>();
                string firstReading = "", secondReading = "", fMaxVal = "" , fMinVal="", sMaxVal = "", sMinVal = "";

                foreach (acc_sensors obj in sens) {
                    if (obj.id == 1)
                    {
                        firstReading = obj.lastValue.ToString();
                        fMaxVal = obj.max_value.ToString();
                        fMinVal = obj.min_value.ToString();

                    }
                    else if (obj.id == 2)
                    {
                        secondReading = obj.lastValue.ToString();
                        sMaxVal = obj.max_value.ToString();
                        sMinVal = obj.min_value.ToString();
                    }
                    if (!String.IsNullOrEmpty(firstReading) && !String.IsNullOrEmpty(secondReading) &&
                        !String.IsNullOrEmpty(fMaxVal) && !String.IsNullOrEmpty(fMinVal) &&
                         !String.IsNullOrEmpty(sMaxVal) && !String.IsNullOrEmpty(sMinVal)
                        )
                        data.Add(new SensorReadings { firstSensor = firstReading, secondSensor = secondReading ,
                                                      fMinVal=fMinVal , fMaxVal=fMaxVal , sMaxVal=sMaxVal , sMinVal=sMinVal
                                                       });
                }
                return Ok(data.Count() > 0 ?data.FirstOrDefault() : new SensorReadings());
            }
            catch (Exception E)
            {
                Status = Bussiness_API_Config.Get_API_Obj("en", "ser_err");
                return Ok(new { Status = Status, Response = new { } });
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
