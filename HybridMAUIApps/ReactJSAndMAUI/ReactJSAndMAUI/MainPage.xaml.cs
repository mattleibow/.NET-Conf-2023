namespace ReactJSAndMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly TodoDataStore _todoDataStore;

        public MainPage()
        {
            InitializeComponent();

            _todoDataStore = new TodoDataStore();
            _todoDataStore.TaskDataChanged += OnTodoDataChanged;

#if DEBUG
            myHybridWebView.EnableWebDevTools = true;
#endif

            myHybridWebView.JSInvokeTarget = new TodoJSInvokeTarget(this, _todoDataStore);

            BindingContext = this;
        }

        public string TodoAppTitle =>
            $"Todo items: {_todoDataStore.GetData().Count}";

        private void OnTodoDataChanged(object? sender, EventArgs e) =>
            OnPropertyChanged(nameof(TodoAppTitle));

        private void SendUpdatedTasksToJS(IReadOnlyList<TodoTask> tasks) =>
            Dispatcher.DispatchAsync(() => myHybridWebView.InvokeJsMethodAsync("globalSetData", tasks));

        private sealed class TodoJSInvokeTarget(MainPage MainPage, TodoDataStore DataStore)
        {
            public void StartTaskLoading() =>
                MainPage.SendUpdatedTasksToJS(DataStore.GetData());

            public void AddTask(TodoTask newTask) =>
                DataStore.AddTask(newTask);

            public void EditTask(string id, string newName) =>
                DataStore.EditTask(id, newName);

            public void DeleteTask(string id) =>
                DataStore.DeleteTask(id);

            public void ToggleCompletedTask(string id) =>
                DataStore.ToggleCompletedTask(id);
        }
    }
}
