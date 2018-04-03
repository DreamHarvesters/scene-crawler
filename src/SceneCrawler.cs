using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace DH.SceneCrawler
{
    public class SceneCrawler
    {
        public void Crawl<ComponentTypeToCrawl>(CrawlParameters<ComponentTypeToCrawl> crawlParameters)
            where ComponentTypeToCrawl : Component
        {
            EditorSceneManager.sceneLoaded += delegate(Scene scene, LoadSceneMode mode)
            {
                ComponentTypeToCrawl[] components =
                    Object.FindSceneObjectsOfType(crawlParameters.ComponentType) as ComponentTypeToCrawl[];

                CrawlResult<ComponentTypeToCrawl> result =
                    new CrawlResult<ComponentTypeToCrawl>(components);

                if (crawlParameters.OnCrawlingEnd != null)
                    crawlParameters.OnCrawlingEnd(result);
            };

            foreach (string sceneName in crawlParameters.SceneList)
            {
                if (!EditorSceneManager.GetActiveScene().name.Equals(sceneName))
                    EditorSceneManager.LoadScene(sceneName);
            }
        }
    }
}