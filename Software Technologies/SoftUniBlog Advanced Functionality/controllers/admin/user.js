const User = require('mongoose').model('User');
const Role = require('mongoose').model('Role');
const encryption = require('./../../utilities/encryption');

module.exports = {
    all: (req, res) => {
        User.find({}).then(users => {

            for (let user of users) {
                user.isInRole('Admin').then(isAdmin => {
                    user.isAdmin = isAdmin;
                });
            }

            res.render('admin/user/all', {users: users})
        });
    },

    editGet: (req, res) => {
        let id = req.params.id;

        User.findById(id).then(user => {
            Role.find({}).then(roles => {
                for (let role of roles) {
                    if (user.roles.indexOf(role.id) !== -1) {
                        role.isChecked = true;
                    }
                }

                res.render('admin/user/edit', {user: user, roles: roles})
            })
        });
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let userArgs = req.body;

        User.findOne({email: userArgs.email, _id: {$ne: id}}).then(user => {
            let errorMsg = '';
            if (user) {
                errorMsg = 'User with the same username exists!';
            } else if (!userArgs.email) {
                errorMsg = 'Email cannot be null!'
            } else if (!userArgs.fullName) {
                errorMsg = 'Name cannot be null!'
            } else if (userArgs.password !== userArgs.confirmedPassword) {
                errorMsg = 'Passwords do not match!'
            }

            if (errorMsg) {
                userArgs.error = errorMsg;
                res.render('admin/user/edit', userArgs);
            } else {
                Role.find({}).then(roles => {
                    if(!userArgs.roles) {
                        userArgs.roles =[];
                    }

                    let newRoles = roles.filter(role => {
                        return userArgs.roles.indexOf(role.name) !== -1;
                    }).map(role => {
                        return role.id;
                    });

                    User.findOne({_id : id}).then(user => {
                        user.email = userArgs.email;
                        user.fullName = userArgs.fullName;

                        let passwordHash = user.passwordHash;
                        if (userArgs.password) {
                            passwordHash = encryption.hashPassword(userArgs.password, user.salt);
                        }

                        user.passwordHash = passwordHash;
                        user.roles = newRoles;

                        user.save((err) => {
                            if (err) {
                                res.redirect('/');
                            } else {
                                res.redirect('/admin/user/all');
                            }
                        })
                    })
                });
            }
        });
    },

    deleteGet: (req, res) => {
        let id = req.params.id;
        User.findById(id).then(user => {
            res.render('admin/user/delete', { userToDelete: user})
        });
    },

    deletePost: (req, res) => {
        let id = req.params.id;

        User.findOneAndRemove({_id: id}).then(user => {
            user.prepareDelete();
            res.redirect('/admin/user/all');
        })
    }
};

