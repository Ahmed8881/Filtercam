# FilterCam  - Camera Web App 📸

A modern, feature-rich camera web application built with vanilla JavaScript, HTML5, and CSS3. Capture stunning photos with beautiful filters, create amazing collages, and enjoy a professional camera experience right in your browser.

## ✨ Features

### 🎥 Camera Functionality
- **Live Camera Feed** - Real-time video preview with high-quality streaming
- **Front/Back Camera Switch** - Toggle between front and rear cameras
- **Timer Capture** - Configurable timer (3, 5, or 10 seconds) with countdown animation
- **Flash Effect** - Simulated camera flash for better photo experience
- **Grid Lines** - Rule of thirds grid overlay for perfect composition

### 🎨 Creative Filters
- **8 Professional Filters** including:
  - Original (no filter)
  - Black & White
  - Sepia
  - Vintage
  - Cool Blue
  - Warm Sunset
  - Dramatic
  - Neon Glow
- **Real-time Filter Preview** - See filters applied instantly to live video
- **Filter Indicators** - Visual previews and current filter display

### 📷 Photo Management
- **Photo Gallery** - Beautiful grid layout for captured photos
- **Photo Limit** - Capture up to 3 photos for collage creation
- **Photo Preview** - Full-size photo viewing with metadata
- **Download Photos** - Save individual photos to device
- **Delete Photos** - Remove unwanted photos from gallery

### 🎨 Collage Creation
- **Automatic Collage Generation** - Create stunning collages from 3 photos
- **Beautiful Layouts** - Professional collage templates with gradients
- **Decorative Elements** - Add artistic touches to your collages
- **Custom Text** - Automatic date and app branding
- **Download Collages** - Save collages in high quality
- **Share Functionality** - Native sharing support when available

### ⚙️ Settings & Customization
- **Timer Settings** - Adjust capture delay
- **Sound Effects** - Toggle camera sounds on/off
- **Flash Control** - Enable/disable flash effect
- **Photo Quality** - Adjust image compression settings
- **Grid Lines** - Toggle composition grid

### 🎵 Audio Features
- **Shutter Sound** - Realistic camera shutter sound
- **Timer Beep** - Countdown timer audio feedback
- **Sound Controls** - Mute/unmute all audio effects

## 🚀 Getting Started

### Prerequisites
- Modern web browser with WebRTC support (Chrome, Firefox, Safari, Edge)
- Camera permissions for your browser
- HTTPS connection (required for camera access)

### Installation
1. Clone or download the repository
2. Open `index.html` in your web browser
3. Allow camera permissions when prompted
4. Start capturing amazing photos!

### Local Development
```bash
# For local development, serve files over HTTPS
# Option 1: Using Python
python -m http.server 8000

# Option 2: Using Node.js http-server
npx http-server -p 8000

# Option 3: Using Live Server extension in VS Code
# Install Live Server extension and click "Go Live"
```

## 🎯 Usage

### Taking Photos
1. **Select a Filter** - Choose from 8 creative filters
2. **Set Timer** (optional) - Configure capture delay in settings
3. **Compose Your Shot** - Use grid lines for perfect composition
4. **Click Capture** - Press the camera button to take a photo
5. **View Results** - Photos appear in the gallery section

### Creating Collages
1. **Capture 3 Photos** - Take exactly 3 photos to unlock collage creation
2. **Click "Create Collage"** - Generate your masterpiece
3. **Download or Share** - Save or share your collage

### Managing Photos
- **View Photos** - Click any photo in the gallery for full-size preview
- **Download** - Save individual photos to your device
- **Delete** - Remove photos you don't want to keep
- **Clear All** - Remove all photos from the gallery

## 🛠️ Technical Details

### Technologies Used
- **HTML5** - Semantic markup and structure
- **CSS3** - Modern styling with gradients, animations, and responsive design
- **JavaScript (ES6+)** - Modern JavaScript with classes and async/await
- **WebRTC** - Camera access and media streaming
- **Canvas API** - Image processing and filter effects
- **Local Storage** - Settings persistence
- **Font Awesome** - Beautiful icons
- **Google Fonts** - Poppins font family

### Browser Compatibility
- Chrome 60+
- Firefox 55+
- Safari 11+
- Edge 79+

### File Structure
```
filtercam/
├── index.html          # Main HTML file
├── main.js            # Core JavaScript application
├── styles.css         # CSS styles and animations
├── README.md          # This file
└── .gitignore         # Git ignore rules
```

## 🎨 Customization

### Adding New Filters
Edit the `getFilterCSS()` method in `main.js` to add custom CSS filters:

```javascript
const filters = {
    'custom': 'hue-rotate(120deg) saturate(150%) brightness(110%)',
    // Add your filter here
};
```

### Modifying Collage Layouts
Customize collage positioning in the `getCollagePositions()` method:

```javascript
getCollagePositions(canvasWidth, canvasHeight) {
    return [
        { x: 100, y: 150, width: 350, height: 500 },
        // Modify positions here
    ];
}
```

### Changing Color Schemes
Update CSS custom properties in `styles.css` to change the app's color scheme:

```css
:root {
    --primary-gradient: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    --accent-color: #667eea;
}
```

## 🔒 Privacy & Security

- **No Data Collection** - All processing happens locally in your browser
- **No Server Upload** - Photos never leave your device
- **Camera Permissions** - Only used for live preview and photo capture
- **Local Storage** - Only settings are stored locally

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📱 Mobile Support

The app is fully responsive and works great on mobile devices:
- Touch-friendly interface
- Optimized for portrait and landscape orientations
- Mobile camera switching support
- Responsive grid layouts

## 🐛 Known Issues

- Camera switching may not work on all mobile devices
- Some filters may not render identically across all browsers
- WebRTC requires HTTPS in production environments

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 🙏 Acknowledgments

- Font Awesome for beautiful icons
- Google Fonts for typography
- WebRTC community for camera access standards
- CSS-Tricks for responsive design inspiration

## 📞 Support

If you encounter any issues or have questions:
1. Check the browser console for error messages
2. Ensure camera permissions are granted
3. Try refreshing the page
4. Test in a different browser

---

**Made with ❤️ by PhotoStudio Pro Team**

*Capture life's beautiful moments with style!*