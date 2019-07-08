
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

using SalesReport.Models.Data;
using SalesReport.Models.Entity;

namespace SalesReport.Models.Util
{
    public class CSVReader:ICSVReader
    {
        
        /// <summary>
        /// CSV Reader.
        /// </summary>
        /// <param name="file"></param>
        public void Reader(string file)
        {
            // Instance of Entity Framework Class;
            SalesDBContext db = new SalesDBContext();

            // Delete Data each time import the file
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Sales");

            try
            {
                //CSV PARSER
                using (TextFieldParser parser = new TextFieldParser(file, Encoding.GetEncoding("iso-8859-1")))
                {
                    parser.Delimiters = new string[] { "," };
                    int CurrentLine = 0;
                    while (!parser.EndOfData)
                    {
                        string[] columns = parser.ReadFields();
                        if (columns == null)
                        {
                            break;
                        }
                        //Making empty value as null
                        for (int i = 0; i < columns.Length; i++)
                        {
                            if (columns[i] == "")
                            {
                                columns[i] = null;
                            }
                        }
                        if (CurrentLine != 0)
                        {


                            var newSalesData = new Sales
                            {
                                DealNumber = int.Parse(columns[0]),
                                DealershipName = columns[1],
                                CustomerName = columns[2],
                                Vehicle = columns[3],
                                Price = decimal.Parse(columns[4].Replace(",", ".")),
                                Date = DateTime.Parse(columns[5])

                            };

                            // Add Data to The Database
                            db.Sales.Add(newSalesData);
                            db.SaveChanges();

                        }
                        CurrentLine++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Find the vehicle that was sold the most often.
            SoldMost(db);


        }

        /// <summary>
        /// Find the vehicle that was sold the most often.
        /// </summary>
        /// <param name="db"></param>
        internal void SoldMost(SalesDBContext db)
        {

            if (db.Sales.ToList() != null && db.Sales.ToList().Count > 0)
            {
                var soldMost = db.Sales.ToList()
                                    .GroupBy(q => q.Vehicle)
                                    .OrderByDescending(gp => gp.Count())
                                    .Take(1)
                                    .Select(g => g.Key).First();

                var soldMostVehicle = new Sales
                {
                    DealNumber = 0,
                    DealershipName = string.Empty,
                    CustomerName = string.Empty,
                    Vehicle = string.Empty,
                    Price = 0,
                    Date = DateTime.Now,
                    SoldMost = soldMost
                };
                db.Sales.Add(soldMostVehicle);
                db.SaveChanges();
            }
        }
    }
}