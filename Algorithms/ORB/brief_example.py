import cv2
import numpy as np

# run 'python brief_example.py' in terminal

img = cv2.imread('image2.png', cv2.IMREAD_GRAYSCALE)
fast = cv2.FastFeatureDetector.create()
minThresh = 25
fast.setThreshold(minThresh)
keypoints = fast.detect(img)

brief = cv2.xfeatures2d.BriefDescriptorExtractor_create()
keypoints, descriptors = brief.compute(img, keypoints)

print(brief.descriptorSize())
print(descriptors[0])
print(' '.join(format(x, '02x') for x in descriptors[0]))