(function ($) {

    var model = null;

    var bucketId = null;

    window.bucket = {
        
        initialize: _initialize

    };

    function _initialize(items, bid) {
        model = new _viewModel();
        model.BucketItems($.map(items, _getItemViewModel));
        ko.applyBindings(model);
        bucketId = bid;
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

        var self = this;

        this.Id = null;
        
        this.Text = ko.observable();

        this.Text.subscribe(function (nv) {
            console.log(nv);
        }, this);

        this.ThrottledText = ko.computed(function() {
            return this.Text();
        }, this).extend({ throttle: 500 });

        this.ThrottledText.subscribe(function () {
            var args = {
                text: this.Text(),
                id: this.Id,
                bucketId: bucketId
            };
            $.post('/BucketItems', args, function (bucketItemId) {
                self.Id = bucketItemId;
            });
        }, this);

        this.Remove = function (item) {
            model.BucketItems.remove(item);
        };
    }

})(jQuery);