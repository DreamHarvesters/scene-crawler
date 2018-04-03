using UnityEngine;

namespace DH.SceneCrawler
{
    public class CrawlResult<ComponentTypeToCrawl> where ComponentTypeToCrawl : Component
    {
        private ComponentTypeToCrawl[] components;
        
        public CrawlResult(ComponentTypeToCrawl[] components)
        {
            this.components = components;
        }

        public ComponentTypeToCrawl[] Components
        {
            get { return components; }
        }
    }
}