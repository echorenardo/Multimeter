using System;
using System.Collections.Generic;

namespace Initializing
{
    public class Initializer
    {
        public void Initialize(List<IInitializable> initializables)
        {
            foreach (var initializable in initializables)
                initializable.Initialize();
        }

        public void Dispose(List<IDisposable> disposables)
        {
            foreach (var disposable in disposables)
                disposable.Dispose();
        }
    }
}