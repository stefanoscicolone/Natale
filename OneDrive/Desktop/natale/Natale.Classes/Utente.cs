using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Natale.Classes
{
    public class Utente

    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("password_clear_text")]
        public string Password_Clear { get; set; }

        [BsonElement("screenname")]
        public string ScreenName { get; set; }


        [BsonElement("isAdmin")]
        public Boolean isAdmin { get; set; }




    }
}
