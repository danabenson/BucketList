(function ($) {

    var model = null;

    window.bucket = {
        
        initialize: _initialize

    };

    function _initialize(items) {
        model = new _viewModel();
        model.BucketItems($.map(items, _getItemViewModel));
        ko.applyBindings(model);
    }
    
    function _viewModel() {

        this.BucketItems = ko.observableArray();

        this.AddItem = function() {
            this.BucketItems.push(new _itemViewModel());
        };

        this.Share = function() {
            alert('Not Implemented');
        };
    }

    function _getItemViewModel(item) {
        var itemModel = new _itemViewModel();
        itemModel.Id = item.Id;
        itemModel.Text(item.Text);
        return itemModel;
    }

    function _itemViewModel() {

        this.Id = null;
        
        this.Text = ko.observable();
        
        this.Remove = function (item) {
            model.BucketItems.remove(item);
        };
    }

})(jQuery);