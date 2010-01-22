using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AjaxExamples.Models
{
    public class SpeakerRepository
    {
        //simulate an in memory database
        private static readonly Dictionary<Guid, Speaker> _speakers = new Dictionary<Guid, Speaker>();

        static SpeakerRepository()
        {
            var speaker1 = new Speaker
            {
                Id = Guid.NewGuid(),
                FirstName = "Jimmy",
                LastName = "Bogard",
                PictureUrl = "/content/jimmy.png",
                Bio = "Jimmy is a senior consultant at Headspring Systems in Austin, TX.",
                UrlKey = "jimmy-bogard"
            };
            var speaker2 = new Speaker
            {
                Id = Guid.NewGuid(),
                FirstName = "Jeffrey",
                LastName = "Palermo",
                PictureUrl = "/content/jeffrey.jpg",
                Bio = "Jeffrey Palermo is a Microsoft MVP and Chief Technology Officer of Headspring Systems in Austin, TX.",
                UrlKey = "jeffrey-palermo"
            };
            var speaker3 = new Speaker
            {
                Id = Guid.NewGuid(),
                FirstName = "Ben",
                LastName = "Scheirman",
                PictureUrl = "/content/ben3.png",
                Bio = "Ben Scheirman is a Microsoft MVP and Director of Development at ChaiONE in Houston, TX.",
                UrlKey = "ben-scheirman"
            };

            AddSpeaker(speaker3);
            AddSpeaker(speaker1);
            AddSpeaker(speaker2);
        }

        private static void AddSpeaker(Speaker speaker)
        {
            _speakers.Add(speaker.Id, speaker);
        }

        public IEnumerable<Speaker> FindAll()
        {
            return _speakers.Values;
        }

        public Speaker FindSpeaker(Guid id)
        {
            return _speakers[id];
        }

        public Speaker FindSpeakerByUrlKey(string key)
        {
            //simulate a delay
            Thread.Sleep(400);
            return (from speaker in _speakers.Values
                   where speaker.UrlKey == key
                   select speaker).FirstOrDefault();
        }
    }
}