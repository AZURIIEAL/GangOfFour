namespace Singleton
{
    sealed class UploadService
    //Making class sealed as we dont want any other class to inherit from this class.
    {
        private UploadService() { }

        //A recognizer to identify the instance(can be removed).
        public int UploadId { get; private set; }

        //Best practise is not to add any type of parameters as we will only use one instance.
        private static UploadService? _instance;

        //To make an instance of the class.
        private static readonly object _instanceLock = new object();

        //To Handle Multi-Threading we set an instance lock.

        public static UploadService Instance(int id)
        {
            if (_instance is null)
            {
                //Till here the multi-thread occurs ,and then from here the lock funtionality works.
                lock (_instanceLock)
                {
                    if (_instance is null)
                    {
                        _instance = new UploadService();
                        _instance.UploadId = id;
                    }
                }
            }
            return _instance;
        }
    }
}
