using core.domain;
using System;
using System.Collections.Generic;

namespace core.model
{
    public class StoryDto
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string PostedBy { get; set; }
        public DateTimeOffset Time { get; set; }
        public long Score { get; set; }
        public long CommentCount { get; set; }

        public static IEnumerable<StoryDto> Create(IEnumerable<Story> domainStories)
        {
            var listOfStories = new List<StoryDto>();
            Story current = null;

            var enumerator = domainStories.GetEnumerator();

            while (enumerator.MoveNext())
            {
                current = enumerator.Current;

                listOfStories.Add(
                    new StoryDto
                    {
                        CommentCount = current.descendants,
                        PostedBy = current.by,
                        Score = current.score,
                        Time = DateTimeOffset.FromUnixTimeSeconds(current.time),
                        Title = current.title,
                        Uri = current.url
                    });
            }

            return listOfStories;
        }
    }   
}
