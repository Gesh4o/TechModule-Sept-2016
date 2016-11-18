const mongoose = require('mongoose');

let categorySchema = mongoose.Schema({
    name: {type: String, required: true, unique: true},
    articles: [{type: mongoose.Schema.Types.ObjectId, ref:'Article'}]
});

categorySchema.method({
    prepareDelete: function () {
        let Article = mongoose.model('Article');
        for (let article of this.articles){
            Article.findById(article).then(article => {
                article.prepareDelete();
                article.remove();
            })
        }
    }
});

categorySchema.set('versionKey', false);

const Category = mongoose.model('Category', categorySchema);

module.exports = Category;
