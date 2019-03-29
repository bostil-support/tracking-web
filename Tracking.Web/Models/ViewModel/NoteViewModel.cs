﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models.ViewModel
{
    public class NoteViewModel
    {
        /// <summary>
        /// note text
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// User of new note
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// relationship with Survey
        /// </summary>
        public int SurveyId { get; set; }

        /// <summary>
        /// Attached file
        /// </summary>        
        public IFormFile File { get; set; }

        /// <summary>
        /// Note date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
