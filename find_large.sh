#!/bin/bash
git rev-list --objects main | git cat-file --batch-check='%(objecttype) %(objectname) %(objectsize) %(rest)' | awk '$3 > 50000000 {print $4, $3}' > large_in_main.txt
