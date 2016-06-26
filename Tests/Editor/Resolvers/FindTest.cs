﻿using NUnit.Framework;
using Syrinj.Attributes;
using Syrinj.Exceptions;
using Syrinj.Injection;
using UnityEngine;

namespace Syrinj.Tests.Resolvers
{
    [TestFixture]
    internal class FindTest
    {
        private const string NAME = "TEST_NAME";

        internal class FindTestClass : MonoBehaviour
        {
            [Find(NAME)] public GameObject dependency;
        }

        private GameObject dependency;
        private FindTestClass behaviour;

        [Test]
        public void InjectNotNull()
        {
            SetUpBehaviourAndSceneObjectAndInject();

            Assert.NotNull(behaviour.dependency);
        }

        private void SetUpBehaviourAndSceneObjectAndInject()
        {
            var obj = new GameObject();
            behaviour = obj.AddComponent<FindTestClass>();

            dependency = new GameObject(NAME);

            new MonoBehaviourInjector(behaviour).Inject();
        }

        [Test]
        public void InjectIsExpectedDependency()
        {
            SetUpBehaviourAndSceneObjectAndInject();

            Assert.AreEqual(dependency, behaviour.dependency);
        }

        [Test]
        [ExpectedException(typeof(InjectionException))]
        public void InjectNull()
        {
            SetUpBehaviourWithoutSceneObjectAndInject();

            Assert.Null(behaviour.dependency);
        }

        private void SetUpBehaviourWithoutSceneObjectAndInject()
        {
            var obj = new GameObject();
            behaviour = obj.AddComponent<FindTestClass>();

            new MonoBehaviourInjector(behaviour).Inject();
        }

        [TearDown]
        public void TearDown()
        {
            if (dependency != null) GameObject.DestroyImmediate(dependency);
        }
    }
}
