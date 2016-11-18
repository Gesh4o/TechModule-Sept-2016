const Article = require('mongoose').model('Article');
const Tag = require('mongoose').model('Tag');

module.exports = {
    listArticlesByTag: (req, res) => {
        let name = req.params.name;

        Tag.findOne({name: name}).then(tag => {
            Article.find({tags: tag.id}).populate('author tags')
                .then(articles => {
                res.render('tag/details',{articles: articles, tag : tag});
            })
        })
    }
};


