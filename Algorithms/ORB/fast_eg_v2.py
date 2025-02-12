import cv2
import numpy as np

def fast_detection(image, threshold = 25):
    keypoints = []
    rows, cols = image.shape[:2]

    print('detecting...')
    for y in range(3, rows - 3):
        for x in range(3, cols - 3):
            p = image[y, x]
            intensity_list = [
                image[y - 3, x], image[y - 3, x + 1], image[y - 2, x + 2], image[y - 1, x + 3],
                image[y, x + 3], image[y + 1, x + 3], image[y + 2, x + 2], image[y + 3, x + 1],
                image[y + 3, x], image[y + 3, x - 1], image[y + 2, x - 2], image[y + 1, x - 3],
                image[y, x - 3], image[y - 1, x - 3], image[y - 2, x - 2], image[y - 3, x - 1]
            ]

            count_brighter = 0
            count_darker = 0

            for i in range(16):
                if np.int64(intensity_list[i]) - np.int64(p) > threshold:
                    count_brighter += 1
                elif np.int64(p) - np.int64(intensity_list[i]) > threshold:
                    count_darker += 1

            if count_brighter >= 9 or count_darker >= 9:
                keypoints.append((x, y))
    print('end')

    return keypoints

image = cv2.imread('image2.png', cv2.IMREAD_GRAYSCALE)

keypoints = fast_detection(image, 25)

for x, y in keypoints:
    cv2.circle(image, (x, y), 6, (0, 100, 255), -1)

cv2.imshow('FAST Keypoints', image)
cv2.waitKey(0)
cv2.destroyAllWindows()