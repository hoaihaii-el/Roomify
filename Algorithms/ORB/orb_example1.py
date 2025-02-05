import cv2

img = cv2.imread('image2.png', 0)
orb = cv2.ORB_create()

# detect points
kp, des = orb.detectAndCompute(img, None)
img_with_kp = cv2.drawKeypoints(img, kp, None, color=(0, 255, 0))

# show image
cv2.imshow('ORB Features', img_with_kp)
cv2.waitKey(0)
cv2.destroyAllWindows()

# ternimal to run -> python orb_example1.py