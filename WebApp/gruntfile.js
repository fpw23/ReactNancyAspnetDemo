module.exports = function (grunt) {
    'use strict';
    // Project configuration
    grunt.initConfig({
        // Metadata
        pkg: grunt.file.readJSON('package.json'),
        banner: '/*! &lt%= pkg.name %> - v&lt;%= pkg.version %> - ' +
            '&lt;%= grunt.template.today("yyyy-mm-dd") %> */\n',
        concat: {
            options: {
                stripBanners: true
            },
            corejs: {
                src: [
                    './node_modules/jquery/dist/jquery.js',
                    './node_modules/bootstrap/dist/js/bootstrap.js',
                ],
                dest: './Content/JS/app.core.js'
            },
            corecss: {
                src: [
                    './node_modules/bootstrap/dist/css/bootstrap.css'
                ],
                dest: './Content/CSS/app.core.css'
            },
            themecss: {
                src: [
                    './Other/themes/bootstrap.theme.flatty.css',
                    './Other/extra.css'
                ],
                dest: './Content/CSS/app.theme.css'
            },

        },
        uglify: {
            options: {
                banner: '<%= banner %>',
                sourceMap: true,
                compress: {
                    drop_console: true
                }
            },
            corejs: {
                src: ['<%= concat.corejs.dest %>'],
                dest: './Content/JS/app.core.min.js'
            }
        },
        cssmin: {
            corecss: {
                src: ['<%= concat.corecss.dest %>'],
                dest: './Content/CSS/app.core.min.css'
            },
            themecss: {
                src: ['<%= concat.themecss.dest %>'],
                dest: './Content/CSS/app.theme.min.css'
            }
        }
    });

    // These plugins provide necessary tasks
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    // Tasks
    grunt.registerTask('core', ['concat:corejs', 'concat:corecss', 'concat:themecss', 'uglify:corejs', 'cssmin:corecss', 'cssmin:themecss']);
};