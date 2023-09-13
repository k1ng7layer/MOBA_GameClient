using NUnit.Framework;
using UnityEngine;
using Utils.ZenjectUtils;
using Zenject;

namespace Tests.Utils
{
    public abstract class NetworkTestBase
    {
        [SetUp]
        public void Setup()
        {
            ResourceSubstitute.Clear();
            SubstituteResources();
        }

        protected abstract void SubstituteResources();

        [TearDown]
        public void TearDown()
        {
            ResourceSubstitute.Clear();
            Object.Destroy(ProjectContext.Instance.gameObject);
        }
    }
}