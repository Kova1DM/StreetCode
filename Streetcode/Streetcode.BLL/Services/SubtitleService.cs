
using Repositories.Realizations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class SubtitleService : ISubtitleService 
    {

        public SubtitleService() 
        {
        }

        private RepositoryWrapper RepositoryWrapper;

        public string GetSubtitlesByStreetcode() 
        {
            return "GetSubtitlesByStreetcode";
            // TODO implement here
        }

    }
}