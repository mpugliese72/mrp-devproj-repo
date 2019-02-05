using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONConsoleApp
{
    public class Program
    {
        /*public static object JObject { get; private set; }*/

        public int Id { get; set; }
        public string Channel { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }

        static void Main(string[] args)
        {
            string json = @"{
            'id': 1145,
                'channel': {
                    'title': 'James Newton-King',
                    'link': 'http://james.newtonking.com',
                    'description': 'James Newton-King\'s blog.',
                    'state': 'CO',
                    'item': [
                        {
                        'title': 'TITLE1 - Json.NET 1.3 + New license + Now on CodePlex',
                        'description': 'Announcing the release of Json.NET 1.3, the MIT license and the source on CodePlex',
                        'link': 'http://james.newtonking.com/projects/json-net.aspx',
                        'category': [
                            'Json.NET',
                            'CodePlex'
                        ]
                        },
                          {
                            'title': 'LINQ to JSON beta',
                            'description': 'Announcing LINQ to JSON',
                            'link': 'http://james.newtonking.com/projects/json-net.aspx',
                            'category': [
                              'Json.NET',
                              'LINQ'
                            ]
                          }
                        ]
                      },
                'id': 1155,
                    'channel': {
                        'title': 'King Edward II',
                        'link': 'http://king.edwardII.com',
                        'description': 'King Edward II\'s blog.',
                        'state': 'PA',
                        'item': [
                            {
                            'title': 'TEST Json.NET 1.3 + New license + Now on CodePlex',
                            'description': 'TEST Announcing the release of Json.NET 1.3, the MIT license and the source on CodePlex',
                            'link': 'http://TEST1james.newtonking.com/projects/json-net.aspx',
                            'category': [
                                'TESTJson.NET',
                                'TESTCodePlex'
                            ]
                            },
                              {
                                'title': 'TEST LINQ to JSON beta',
                                'description': 'TEST Announcing LINQ to JSON',
                                'link': 'http://TEST2james.newtonking.com/projects/json-net.aspx',
                                'category': [
                                  'TESTJson.NET',
                                  'TESTLINQ'
                                ]
                              }
                            ]
                          }
                        }";

            /*string json = @"{
                    'id': 1145,
                        'consumer': [{
                            'age': 60,
                            'credit_rating': 'Good',
                            'address': '207 some_fake_road_name ln.',
                            'address2': '',
                            'state': 'IL',
                            'zip_code': '60440',
                            'area_code': '',
                            'city': 'Bolingbrook',
                            'county': 'WILL',
                            'primary_phone': '708-113-0101',
                            'first_name': 'joeseph',
                            'last_name': 'schmoe',
                            'email': 'eggo-test-thing99@gmail.com',
                            'years_at_address': 5,
                            'is_currently_at_address': false,
                            'secondary_phone': '708-001-0900',
                            'own_or_rent': 'OWN',
                            'comments': '',
                            'contact_method': 'phone',
                            'birthdate': '1967-07-06',
                            'occupation': 'SelfEmployed',
                            'highest_level': 'AssociateDegree',
                            'gender': 'Male',
                            'property_type': ''
                        },
                        'vehicle': 
                            {
                                'year': 2013,
                                'make': 'CHEVROLET',
                                'model': 'EQUINOX LS',
                                'EngineInformation': '',
                                'days_used': 5,
                                'use': 'Commute_Work',
                                'distance': 3,
                                'annual_distance': 10000
                            },
                        'coverage': {
                            'months_insured': '48',
                            'has_coverage': 'YES',
                            'type': 'STATE_MIN',
                            'bodilyinjury_person': 25000,
                            'bodilyinjury_accident': 50000,
                            'deductible': 2000,
                            'propertydamage': 10000,
                            'expiration_date': '2018-04-30',
                            'expiration_days_remaining': 30,
                            'dtgExpirationDate': '2018-04-30',
                            'former_insurer': 'Some Small Company'
                        }]
                    }
                ]";*/

           JObject jsonData = JObject.Parse(json);

            var listTitles =
                /*from c in rss["channel"]["item"].Children()["category"].Values<string>()*/
                from jd in jsonData["channel"]["item"].Children()["title"].Values<string>()
                group jd by jd
                into jd2
                select new { Title = jd2.Key };

            var listDescriptions =
                /*from c in rss["channel"]["item"].Children()["category"].Values<string>()*/
                from jd in jsonData["channel"]["item"].Children()["description"].Values<string>()
                group jd by jd
                into jd2
                select new { Description = jd2.Key };

            var listLinks =
               /*from c in rss["channel"]["item"].Children()["category"].Values<string>()*/
               from jd in jsonData["channel"]["item"].Children()["link"].Values<string>()
               group jd by jd
               into jd2
               select new { Link = jd2.Key };

            Console.WriteLine("TITLES:");
            foreach (var list in listTitles)
            {
                Console.WriteLine(list.Title);
            }
            Console.WriteLine();
            Console.WriteLine("DESCRIPTIONS:");
            foreach (var lists in listDescriptions)
            {
                Console.WriteLine("Description: " + lists.Description);
            }
            Console.WriteLine();
            Console.WriteLine("LINKS:");
            foreach (var lists in listLinks)
            {
                Console.WriteLine("Link: " + lists.Link);
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();


            /*dynamic data = System.Web.Helpers.Json.Decode("{" + json + "}");*/

            var serializer = new JsonSerializer();
            /*dynamic result = serializer.Deserialize<Products>(json);
            var result2 = result["id"];
            var result3 = result["title"];
            var result4 = result["link"];
            var result5 = result["description"];

            Console.WriteLine("Id: " + result2);
            Console.WriteLine("Title: " + result3);
            Console.WriteLine("Link: " + result4);
            Console.WriteLine("Description: " + result5);*/


            /*
            var program = new JavaScriptSerializer().Deserialize<Program>(json);
            var test = program.Id;

            Console.WriteLine("Id returned from JavaScriptSerializer: " + test);
            */
                     
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();
            /* maybe */
            Console.WriteLine();
            string itemTitle1 = (string)jsonData["channel"]["item"][0]["title"];
            string itemTitle2 = (string)jsonData["channel"]["item"][1]["title"];
            Console.WriteLine("Specific Title 1: " + itemTitle1 + "\n" +
                                "Specific Title 2: " + itemTitle2);

            Console.WriteLine();
            string itemId = (string)jsonData["id"];
            Console.WriteLine("Specific Id: " + itemId);



            /*
            Console.WriteLine();

            string title2 = (string)jsonData["channel"]["title"];
            Console.WriteLine("Channel Title: " + title2);

            Console.WriteLine();

            var titles =
                from jd in jsonData["channel"]["item"]
                select (string)jd["title"];

            foreach (var title in titles)
            {
                Console.WriteLine("Item Title: " + title);
            }
            */

            Console.ReadKey();

            /*
            var ids =
                from jd in jsonData["id"]
                select (string)jd["id"];

            foreach (var id in ids)
            {
                Console.WriteLine("Id: " + id);
                Console.WriteLine();
            }
            Console.ReadKey();
            */

            /* AFTER PRIMARY PHONE
             * 'first_name': 'john',
              'last_name': 'doe',
              'email': 'j.doe.22234@gmail.com',*/

        }
    }
}
