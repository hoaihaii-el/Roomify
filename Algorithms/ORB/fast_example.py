import cv2 as cv
import numpy as np

# run 'python fast_example.py' in terminal
imgGray = cv.imread('image2.png', cv.IMREAD_GRAYSCALE)

# init fast detector
fast = cv.FastFeatureDetector.create()
minThresh = 25
fast.setThreshold(minThresh)
keypoints = fast.detect(imgGray)
fastOutput = cv.drawKeypoints(imgGray, keypoints, imgGray, flags=cv.DRAW_MATCHES_FLAGS_DRAW_RICH_KEYPOINTS)

cv.imshow('original', imgGray)
cv.imshow('FAST Features', fastOutput)
cv.waitKey(0)
cv.destroyAllWindows()