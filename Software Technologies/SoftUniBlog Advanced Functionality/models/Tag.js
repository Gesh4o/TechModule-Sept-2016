const mongoose = require('mongoose');

let tagsSchema = mongoose.Schema({
    name: {type: String, required: true, unique: true},
    articles: [{type: mongoose.Schema.Types.ObjectId, ref:'Article'}]
});

tagsSchema.method({
    prepareInsert: function () {
        let Article = mongoose.model('Article');
        for (let article of this.articles){
            Article.findById(article).then(article => {
                if (article.tags.indexOf(this.id) === -1){
                    article.tags.push(this.id);
                    article.save();
                }
            });
        }
    },

    deleteArticle: function (articleId) {
        this.articles.remove(articleId);
        this.save();
    }
});

tagsSchema.set('versionKey', false);
const Tag = mongoose.model('Tag', tagsSchema);

module.exports = Tag;

module.exports.initializeTags =  function (newTags, articleId) {
    for (let newTag of newTags) {
        if(newTag){
            Tag.findOne({name: newTag}).then(tag => {
                // If is existing - insert the article in it.
                if (tag) {
                    if(tag.articles.indexOf(articleId) === -1) {
                        tag.articles.push(articleId);
                        tag.prepareInsert();
                        tag.save();
                    }
                }
                // If not - create and insert the article.
                else {
                    Tag.create({name: newTag}).then(tag => {
                        tag.articles.push(articleId);
                        tag.prepareInsert();
                        tag.save();
                    })
                }
            });
        }
    }
};
