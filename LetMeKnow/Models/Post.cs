using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Models {
    public class Post {
        public string Uid { get; set; }
        public string Text { get; set; }
        //public string Image { get; set; }
        public int CreateTime { get; set; }
        public int LastEditTime { get; set; }
    }
}
