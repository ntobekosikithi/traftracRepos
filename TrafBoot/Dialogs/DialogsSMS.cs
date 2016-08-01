using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Device.Location;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using TrafBoot.Models;

namespace TrafBot.Dialogs
{
    [LuisModel("ebea50c6-bc59-4819-8758-82b5c5ee71f9", "e686ad6ca03b4cf29d26288783935568")]
    [Serializable]
    public class DialogsSMS : LuisDialog<object>
    {
        string[] imgUrl = { "https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%200010A&time=1469440518926"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20014&time=1469794433388"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20003&time=1469515338615"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20035&time=1469515018541"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20016&time=1469440802920"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20030&time=1469524351534"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20022&time=1469440944936"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20035&time=1469441045960"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20106&time=1469441145981"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20001"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20019"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=WC&deviceID=WC%20CCTV%20N2%20212&time=1469794576184"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20034&time=1469514757520"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20051&time=1469514717511"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20125&time=1469454307901"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20112&time=1469524554544"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20144&time=1469524636522"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20111&time=1469524677523"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20119&time=1469524717535"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20137&time=1469524799526"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20149&time=1469524902508"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%200211b&time=1469524983512"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20122&time=1469525063610"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N3%20105&time=1469525165529"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=WC&deviceID=WC%20CCTV%20N2%20225&time=1469794536169"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20023&time=1469794861168"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20049&time=1469794961178"
                             ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20006&time=1469795024182"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20015"
                            ,"https://www.i-traffic.co.za/CctvImageHandler.ashx?networkID=KZN&deviceID=KZN%20CCTV%20N2%20038&time=1469795106178"};
        string[] descp = { "N2 near Kenyon Howden bridge",
                           "N2 before Sarnia Rd I/C ",
                           "N2 at Umlazi off-ramp ",
                           "N2 near Sunningdale/KwaMashu"
                            , "N2 before Edwin Swales Drive Northbound",
                            " N2 at Queen Nandi Drive (M45)",
                           "N2 at Cloete Interchange North",
                           "N2 near Sunningdale/KwaMashu",
                           "N3 before St James Av Southbound",
                           "N2 before Prospecton Rd I/C",
                        "N2 at Ridge View",
                        "N2 OB at Modderdam",
                        " N2 at KwaMashu Highway (R102)",
                        "N2 at Watson Highway (M43)",
                        "N3 Before Marianhill Toll plaza"
                         ,"	N3 at Umbilo River bridge ",
                        "N3 before Hammarsdale I/C Southbound ",
                        "N3 at King Cetshwayo Highway",
                        "N3 after Richmond Rd Southbound"
                        ,"N3 at Key Ridge Truck Stop ",
                        "N3 after Engen One Stop Southbound",
                        "N3 after Market Rd ",
                        "N3 at Stockville/Mahogany Ridge I/C"
                        ,"N3 at Spine Rd (Pavilion I/C) ",
                        "N2 OB before Baden Powell",
                        "N2 at Jan Smuts Highway (M13) "
                        ,"N2 at King Shaka Airport "
                        ,"N2 at Hull Rd"
                        ,"N2 at Sarnia Rd & Railway bridge"
                        ,"N2 at Somerset Park"
                        };


        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand: " +result.Query;
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intent.trafbots.help")]
        public async Task help(IDialogContext context, LuisResult result)
        {
            string message = $"__Supported commands and Tips__ \r\n\r\n  Use words such as show and get when acquiring information for__example__ [ * show current incidents in kwazulu Natal roads* ] \r\n\r\n " +
                            "For searching travel times : __TM:street name__  [TM:anton lembede]\r\n\r\n for searching images of roads : __IMG: road name__ [IMG:N2 at Umlazi]";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intent.trafbot.sms")]
        public async Task SMS(IDialogContext context, LuisResult result)
        {
            /*var url = $"https://rest.nexmo.com/sms/json?api_key=2a4d944b&api_secret=e269766fd4fea8c4&from=NEXMO&to=27794568620&text=Welcome+to+Nexmo";*/
            string message = $"Your SMS message was successfully sent";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intent.trafbots.start")]
        public async Task start(IDialogContext context, LuisResult result)
        {
            string message = $"Hello my name is __traftrac__... With me you will never get stuck in traffic \r\n\r\n"+
                "These are services i can provide you with :showing roads with traffic, incidents, road works, travel times and viewing live street cameras \r\n\r\n __for help__ \r\n\r\n Just type in * help *";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
            
        }

        [LuisIntent("intent.trafbots.end")]
        public async Task end(IDialogContext context, LuisResult result)
        {
            string message = $"Thank you!!! I hope you are satisfied with my services...";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intent.trafbots.gettraffic")]
        public async Task traffic(IDialogContext context, LuisResult result)
        {
            
            string message = $"Thanks for using __traftrac__";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
                    
        }


        [LuisIntent("intent.trafbots.getincidents")]
        public async Task incidents(IDialogContext context, LuisResult result)
        {
            string incidents = "";
            using (var client = new HttpClient())
            {
                var url = $"https://www.i-traffic.co.za/Feeds.ashx?type=incidents&region=KZN";
                //Substring(res.IndexOf("{"), res.LastIndexOf
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                var json = JsonConvert.SerializeXmlNode(doc).ToString();

                try
                {
                    var output = JsonConvert.DeserializeObject<results>(json);

                    int count = output.rss.channel.item.Count;

                    incidents = "### These incidents were found :";
                    
                    for (int i = 0; i < count; i++)
                    {
                        incidents += "\r\n\r\n + " + output.rss.channel.item[i].title + "\r\n\r\n  >  " + output.rss.channel.item[i].pubDate + "\r\n\r\n" + "=======================";
                    }
                    string message = $"{incidents}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);

                }
                catch (Exception)
                {

                    

                    try
                    {
                        var output = JsonConvert.DeserializeObject<resultsItem>(json);

                        incidents = "### One incident was found in :";
                        incidents += "\r\n\r\n  + "+ output.rss.channel.item.title + "\r\n\r\n > " + output.rss.channel.item.pubDate + "\r\n\r\n" + "=======================";

                        string message = $"{incidents}";
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);

                       
                    }
                    catch (Exception)
                    {

                        incidents = "No incidents were found on roads!!";
                        string message = $"{incidents}";
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);
                    }
                }

                
            }


        }


        [LuisIntent("intent.trafbots.getroadworks")]
        public async Task roadworks(IDialogContext context, LuisResult result)
        {
            string incidents = "";
            using (var client = new HttpClient())
            {
                var url = $"https://www.i-traffic.co.za/Feeds.ashx?type=roadwork&region=KZN";
                //Substring(res.IndexOf("{"), res.LastIndexOf
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                var json = JsonConvert.SerializeXmlNode(doc).ToString();

                try
                {
                    var output = JsonConvert.DeserializeObject<results>(json);

                    int count = output.rss.channel.item.Count;

                    incidents = "### These road works were found :";

                    for (int i = 0; i < count; i++)
                    {
                        incidents += "\r\n\r\n + " + output.rss.channel.item[i].title + "\r\n\r\n > " + output.rss.channel.item[i].pubDate + "\r\n\r\n" + "=======================";
                    }
                    string message = $"{incidents}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);
                    
                  
                }
                catch (Exception)
                {

                   try
                    {
                        var output = JsonConvert.DeserializeObject<resultsItem>(json);
                        incidents = "### Only one road work found :";

                        incidents += "\r\n\r\n + " + output.rss.channel.item.title + "\r\n\r\n > " + output.rss.channel.item.pubDate + "\r\n\r\n" + "=======================";
                        string message = $"{incidents}";
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);
                       
                    }
                    catch (Exception)
                    {

                        incidents = "No road works were found around KWazulu Natal!!";
                        string message = $"{incidents}";
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);
                    }
                }
            
            }


        }


        [LuisIntent("intent.trafbots.getTraveltimes")]
        public async Task traveltimes(IDialogContext context, LuisResult result)
        {
            string incidents = "";
            using (var client = new HttpClient())
            {
                var url = $"https://www.i-traffic.co.za/Feeds.ashx?type=traveltimes";

                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                var json = JsonConvert.SerializeXmlNode(doc).ToString();
                //var output = JsonConvert.DeserializeObject<results>(json);


                try
                {
                    var output = JsonConvert.DeserializeObject<results>(json);

                    int count = output.rss.channel.item.Count;

                    incidents = "### These current travel times in kwazulu natal roads :";

                    for (int i = 0; i < count; i++)
                    {
                        incidents += "\r\n\r\n + " + output.rss.channel.item[i].title + "\r\n\r\n > " + output.rss.channel.item[i].pubDate + "\r\n\r\n" + "=======================";
                    }
                    string message = $"{incidents}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);


                }
                catch (Exception)
                {
                    string message = $"Something went wrong on trying to retrieve current travel times";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);
                }
            }


        }


        [LuisIntent("intent.trafbots.getImages")]
        public async Task camera(IDialogContext context, LuisResult result)
        {
            string incidents = "";
            using (var client = new HttpClient())
            {

                //var response = client.GetAsync(url).Result;
                //var res = response.Content.ReadAsStringAsync().Result;
                //XmlDocument doc = new XmlDocument();
                //doc.LoadXml(res);intent.trafbots.searchImages
                //var json = JsonConvert.SerializeXmlNode(doc).ToString();
                //var output = JsonConvert.DeserializeObject<results>(json);

                try
                {
                    
                    var url = "";

                    for (int i = 0; i < 30; i++)
                    {
                        url += "![" + descp[i] + "](" + imgUrl[i] + ")";
                    }

                    //incidents = "$[![incidents](url)]";
                    incidents = "";
                    string message = $"{url}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);

                }
                catch (Exception)
                {

                    incidents = "Something went wrong when trying to retrieve live camera images!!";
                    string message = $"{incidents}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);
                }
            }

        }

        [LuisIntent("intent.trafbots.search")]
        public async Task search(IDialogContext context, LuisResult result)
        {
            string incidents = "";
            using (var client = new HttpClient())
            {
                var url = $"https://www.i-traffic.co.za/Feeds.ashx?type=traveltimes";

                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                var json = JsonConvert.SerializeXmlNode(doc).ToString();

                try
                {
                    var output = JsonConvert.DeserializeObject<results>(json);

                    int count = output.rss.channel.item.Count;

                    string road = result.Query.Substring(result.Query.IndexOf(':') + 1);
                    incidents = "### Current travel times in:  "+road;
                    
                    Boolean flag = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (output.rss.channel.item[i].title.ToLower().Contains(road.ToLower()))
                        {
                            flag = true;
                            incidents += "\r\n\r\n + " + output.rss.channel.item[i].title + "\r\n\r\n > " + output.rss.channel.item[i].pubDate + "\r\n\r\n" + "=======================";
                        }
                    }

                    if (flag == false)
                    {
                        incidents = "No results found !!! please check if your command matches the format [TM:street name]";
                    }
                    string message = $"{incidents}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);


                }
                catch (Exception)
                {
                    string message = $"Something went wrong on trying to retrieve current travel times";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);
                }
            }


        }

        [LuisIntent("intent.trafbots.searchImages")]
        public async Task imagesSearch(IDialogContext context, LuisResult result)
        {
            //string incidents = "";



                    var url = "";
                    string road= result.Query.Substring(result.Query.IndexOf(':')+1);
                    Boolean flag = false;

                    for (int i = 0; i < 15; i++)
                    {
                        //url += "![" + descp[0] + "](" + imgUrl[0] + ")";
                        if (descp[i].ToLower().Contains(road.ToLower()))
                        {
                            flag = true;
                            url += "![" + descp[i] + "](" + imgUrl[i] + ")";
                        }
                        
                    }

                    if (flag==false)
                    {
                        url = "Im sorry, No camera was found in: "+result.Query.Substring(result.Query.IndexOf(':')+1);
                    }
                    //incidents = "$[![incidents](url)]";
                    //incidents = "";
                    string message = $"{url}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);

        }

        [LuisIntent("intent.trafbots.mapview")]
        public async Task trafficMap(IDialogContext context, LuisResult result)
        {
            var url = "";
            url += "![Durban traffic](http://dev.virtualearth.net/REST/V1/Imagery/Map/Road/Durban%20SouthAfrica?mapLayer=TrafficFlow&key=eU3Lwcd55cVoQNXl7BDO~4madrK6kjWBwZpCjZEO_0w~AvBFlIQ-raRU8ss_bAWWOBacA2EjnxY-1ebUAgDxLDAHOP0WUS9zjzsvnex0-upv)";
            string message = $"{url}";
            await context.PostAsync(message);
            context.Wait(MessageReceived);

        }

        [LuisIntent("intent.trafbots.streetview")]
        public async Task streetMap(IDialogContext context, LuisResult result)
        {
            var url = "";
            url += "![Street map](http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/-29.7367,31.0703/16?&dcl=1&key=eU3Lwcd55cVoQNXl7BDO~4madrK6kjWBwZpCjZEO_0w~AvBFlIQ-raRU8ss_bAWWOBacA2EjnxY-1ebUAgDxLDAHOP0WUS9zjzsvnex0-upv)";
            string message = $"{url}";
            await context.PostAsync(message);
            context.Wait(MessageReceived);

        }
        
        [LuisIntent("intent.trafbots.currentLocation")]
        public async Task Testing(IDialogContext context, LuisResult result)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            try
            {

                watcher.TryStart(false, // Do not suppress permissions prompt.
                   TimeSpan.FromMilliseconds(1000)); // Wait 1000 ms to start.

                GeoCoordinate coord = watcher.Position.Location;

                string message = "";
                string lat, longi;
                if (coord.IsUnknown != true)
                {
                    lat = coord.Latitude.ToString();
                    longi = coord.Longitude.ToString();
                    var url = "![Testing](https://maps.googleapis.com/maps/api/staticmap?center="+lat+","+longi+ "&zoom=15&size=400x400&markers=color:red%7Clabel:C%7C"+lat+","+longi+"&key)";
                    message = $"{url}";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);
                }
                else
                {
                    message = $"Current Coordinates could not be identified";
                    await context.PostAsync(message);
                    context.Wait(MessageReceived);
                }

                
            }
            catch (Exception)
            {
                string message = $"Current location could not be identified";
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }


        }

        [LuisIntent("intent.trafbots.routes")]
        public async Task Routes(IDialogContext context, LuisResult result)
        {
            try
            {
                //string get1 = result.Query.Substring(result.Query.IndexOf("from") + 5);
                //string get2 = result.Query.Substring(result.Query.IndexOf("to") + 2);
                //string start = get1.Substring(0, get1.IndexOf(" "));
                //string end = get2.Substring(0, get1.IndexOf(" "));
                string place = "umhlanga";

                var url = "![Route](http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/Routes?wp.0="+ place + ",ZA;64;1&wp.1="+"Durban"+",ZA;66;2&key=eU3Lwcd55cVoQNXl7BDO~4madrK6kjWBwZpCjZEO_0w~AvBFlIQ-raRU8ss_bAWWOBacA2EjnxY-1ebUAgDxLDAHOP0WUS9zjzsvnex0-upv)";
                string message = $"{url}";
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }
            catch (Exception)
            {
                string message = $"Starting or ending point could not be identified";
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }
            

        }
    }
}