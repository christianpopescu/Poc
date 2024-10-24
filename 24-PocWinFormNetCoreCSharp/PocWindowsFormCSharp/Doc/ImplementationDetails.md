# Implementation Details

## Model of the view

```C#
public class SimpleActionModel
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
```

## View details

* Model implemented as private member and initialized in constructor.

```C#
    public class SimpleActionView : System.Windows.Forms.Form
    {
       ...

        private SimpleActionModel theModel;
        
        ...

        protected SimpleActionView()        // Hide default constructor
        {
            InitializeComponents();
        }

        public SimpleActionView(SimpleActionModel theModel)       // Init model in constructor
        {
            InitializeComponents();
            this.theModel = theModel;
            ModelToView();

    }
```