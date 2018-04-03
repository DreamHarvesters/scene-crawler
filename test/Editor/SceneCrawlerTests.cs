using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using DH.SceneCrawler;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

namespace DH.SceneCrawler
{
    public class SceneCrawlerTests
    {
        [Test]
        public void Crawl_Pass()
        {
            GameObject[] objs = new GameObject[2];
            for (int i = 0; i < 2; i++)
            {
                objs[i] = new GameObject();
                objs[i].AddComponent<Text>();
            }
            
            SceneCrawler crawler = new SceneCrawler();
            
            CrawlParameters<Text> crawlParameters = new CrawlParameters<Text>();
            crawlParameters.SceneList = new [] {EditorSceneManager.GetActiveScene().name};
            crawlParameters.OnCrawlingEnd  += delegate(CrawlResult<Text> result)
            {
                Assert.AreEqual(2, result.Components.Length);
            };

            crawler.Crawl(crawlParameters);
            
            for (int i = 0; i < 2; i++)
            {
                GameObject.DestroyImmediate(objs[i]);
            }
        }

        [Test]
        public void CrawlTestForDeactivatedObjects_Pass()
        {
            int objectCount = 3;
            GameObject[] objs = new GameObject[objectCount];
            for (int i = 0; i < objectCount; i++)
            {
                objs[i] = new GameObject();
                objs[i].AddComponent<Text>();
            }
            objs[objectCount - 1].SetActive(false);

            SceneCrawler crawler = new SceneCrawler();

            CrawlParameters<Text> crawlParameters = new CrawlParameters<Text>();
            crawlParameters.SceneList = new[] {EditorSceneManager.GetActiveScene().name};
            crawlParameters.OnCrawlingEnd += delegate(CrawlResult<Text> result)
            {
                Assert.AreEqual(3, result.Components.Length);
            };

            crawler.Crawl(crawlParameters);

            for (int i = 0; i < objectCount; i++)
            {
                GameObject.DestroyImmediate(objs[i]);
            }
        }
    }
}