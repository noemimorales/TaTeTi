namespace DefaultNamespace
{
    public static class PresenterInitializer
    {
        public static void Init(TatetiView view)
        {
            new TatetiPresenter(view);
        }
    }
}