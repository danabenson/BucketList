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
            var count = model.BucketItems().length;
            if (count < 1) {
                alert('Need 1 or more bucket items.');
                return;
            }
            var text = model.BucketItems()[0].Text();
            var text2 = '';
            if (count > 1) {
                text2 = model.BucketItems()[1].Text();
            }

            var desc = text;
            if (text2) {
                desc += '   ' + text2;
            }
            if (count > 2) {
                desc += '   '+count - 2+' more...';
            }

            var obj = {
                method: 'feed',
                redirect_uri: '',
                link: 'http://localhost/Buckets/View?bucketId=' + bucketId,
                picture: 'http://www.friendsbucketlist.com/Images/PostImage.png',
                name: 'My Bucket List',
                caption: 'caption',
                description: desc
            };

            function callback(response) {
                document.getElementById('msg').innerHTML = "Post ID: " + response['post_id'];
            }

            FB.ui(obj, callback);

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