using System;
using System.IO;
using System.Net;
using System.Text;
using UnityProject.Database;

namespace UnityProject
{
    class Program
    {

        static void Main(string[] args)
        {
            // Instanciating with base URL  
            FirebaseDB firebaseDB =
                new FirebaseDB("https://unityproject-2328a.firebaseio.com/");

            // Referring to Node with name "UnitySample"  
            FirebaseDB unityprojectDb = firebaseDB.Node("SampleProject");

            var data = @"{  
                            'UnityProject': {  
                                'Application': {  
                                    'Config': {  
                                        'Version': '1.0',  
                                        'PackagePath': 'this\\is\\the\\path\\to\\packages'  
                                        }
                                   }  
                               }  
                          }";

            //First lets clean up             
            Delete(firebaseDB);

            //Now lets add some data
            Post(firebaseDB, data);

            //Now get the data and display it
            Get(firebaseDB);

            //Now update the data with a PUT
            Put(firebaseDB, data);

            //Now get the data and display it
            Get(firebaseDB);

            //Now update the data with a Patch
            Patch(firebaseDB);

            //Now get the data and display it
            Get(firebaseDB);

            Console.WriteLine(unityprojectDb.ToString());
            Console.ReadLine();
        }

        public static void Delete(FirebaseDB db)
        {
            Console.WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = db.Delete();
            Console.WriteLine(deleteResponse.Success);
            Console.WriteLine();
            Console.WriteLine("End of DELETE Request");
            Console.ReadLine();
        }

        public static void Post(FirebaseDB db, string data)
        {
            Console.WriteLine("POST Request");
            FirebaseResponse postResponse = db.Post(data);
            Console.WriteLine(postResponse.Success);
            Console.WriteLine();
            Console.WriteLine("End of POST Request");
            Console.ReadLine();
        }

        public static void Get(FirebaseDB db)
        {
            Console.WriteLine("GET Request");
            FirebaseResponse getResponse = db.Get();
            Console.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Console.WriteLine(getResponse.JSONContent);
            Console.WriteLine();
            Console.WriteLine("End of Get Request");
            Console.ReadLine();
        }

        public static void GetVersion(FirebaseDB db)
        {
            Console.WriteLine("GET Request for Version");
            FirebaseResponse getResponse = db.Get();


        }

        public static void Put(FirebaseDB db, string data)
        {
            Console.WriteLine("PUT Request");
            FirebaseResponse putResponse = db.Put(data);
            Console.WriteLine(putResponse.Success);
            Console.WriteLine();
            Console.WriteLine("End of PUT Request");
            Console.ReadLine();
        }

        public static void Patch(FirebaseDB db)
        {
            Console.WriteLine("PATCH Request");
            FirebaseResponse patchResponse = db
                // Use of NodePath to refer path longer than a single Node  
                .NodePath("UnityProject/Application/Config")
                .Patch("{\"Version\":\"2.0\"}");
            Console.WriteLine(patchResponse.Success);
            Console.WriteLine();
            Console.WriteLine("End of PATCH Request");
            Console.ReadLine();
        }
    }
}