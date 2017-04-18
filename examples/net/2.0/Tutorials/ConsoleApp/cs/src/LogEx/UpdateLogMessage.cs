using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.LogEx
{
    class UpdateLogMessage
    {
        public string EntitySchemeName { get; set; }
        public string EntityID { get; set; }
        public string StringForOldEntity { get; set; }
        public string StringForNewEntity { get; set; }
        public UpdateLogMessage(string entitySchemeName, string entityID, string stringForOldEntity, string stringForNewEntity)
        {
            this.EntitySchemeName = entitySchemeName;
            this.EntityID = entityID;
            this.StringForOldEntity = stringForOldEntity;
            this.StringForNewEntity = stringForNewEntity;
        }
    }
}
