#!/bin/sh
# A quick and dirty hack to remove comments from mecrisp-stellaris source files by terry@tjporter.com.au
# Copyright T.Porter 2020 released under the GPL
# usage rcas.sh <file.fs>
# output is file.fs.rcas.fs
sed 's/\\.*$//g' < $1 | sed '/^\s*$/d' | sed 's/([^)]*)//g' > $1.rcas.fs
