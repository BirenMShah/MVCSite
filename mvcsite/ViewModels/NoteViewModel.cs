using mvcsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcsite.ViewModels
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int SrcId { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public NoteType NoteType { get; set; }
    }
}