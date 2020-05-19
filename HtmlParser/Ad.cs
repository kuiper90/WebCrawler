using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace HtmlParser
{
    public class Ad
    {
        private string hyperlink;

        private StreamReader htmlDocument;

        private TransactionType transactionType;

        private PropertyType propertyType;

        private int nrOfRooms;

        private int floor;

        //square meters
        private int surface;

        public Ad()
        { }

        public TransactionType PropertyType
            => transactionType;

        public PropertyType EstateType
            => propertyType;

        public int NrOfRooms
            => nrOfRooms;

        public int Floor
            => floor;
    }
}