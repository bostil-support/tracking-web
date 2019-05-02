﻿using System;
using Tracking.DbInitialize.Providers;

namespace Tracking.DbInitialize
{
    static class Program
    {
        private static readonly DbInitializeProvider _db;
        delegate void Display();

        static Program()
        {
            _db = new DbInitializeProvider();
        }
        static void Main(string[] args)
        {
            //Display display = _db.SetCreateDatabase;
            //display.Invoke();

            //Display display = _db.ImportSurveysAudit;
            //display.Invoke();
            //_db.ImportSurveysAudit();
            //_db.ImportDescriptiveAttrAudit();
            _db.ImportSurveysComplaince();
            //_db.ImportDescriptiveAttrComplaince();

            Console.WriteLine($"\r\n{new string('-', 80)}");
            Console.WriteLine("For continue press any button...");
            Console.ReadKey();
        }
    }
}
