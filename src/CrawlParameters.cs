using System;
using UnityEngine;

namespace DH.SceneCrawler
{
    public class CrawlParameters<ComponentTypeToCrawl> where ComponentTypeToCrawl : Component
    {
        private string[] sceneList;
        
        private Action<CrawlResult<ComponentTypeToCrawl>> onCrawlingEnd;

        public Type ComponentType
        {
            get { return typeof(ComponentTypeToCrawl); }
        }
        
        public Action<CrawlResult<ComponentTypeToCrawl>> OnCrawlingEnd
        {
            get { return onCrawlingEnd; }
            set { onCrawlingEnd = value; }
        }

        public string[] SceneList
        {
            get { return sceneList; }
            set { sceneList = value; }
        }
    }
}