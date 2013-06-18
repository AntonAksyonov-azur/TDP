#region Usings

using UnityEngine;

#endregion

namespace Assets.Test {
    public class CSharpTestDriver : MonoBehaviour
    {
        public bool runTests;


        private void Start()
        {
            if (runTests)
                NUnitLiteUnityRunner.RunTests();
        }
    }
}
