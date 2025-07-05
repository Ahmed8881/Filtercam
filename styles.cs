/* Reset and Base Styles */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Poppins', sans-serif;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    min-height: 100vh;
    overflow-x: hidden;
}

.hidden {
    display: none !important;
}

/* Loading Screen */
.loading-screen {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 9999;
}

.loading-content {
    text-align: center;
    color: white;
}

.camera-icon {
    font-size: 4rem;
    margin-bottom: 1rem;
    animation: pulse 2s infinite;
}

.loading-content h2 {
    font-size: 2rem;
    font-weight: 600;
    margin-bottom: 2rem;
}

.loading-spinner {
    width: 50px;
    height: 50px;
    border: 4px solid rgba(255, 255, 255, 0.3);
    border-top: 4px solid white;
    border-radius: 50%;
    animation: spin 1s linear infinite;
    margin: 0 auto 1rem;
}

.loading-content p {
    font-size: 1.1rem;
    opacity: 0.9;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}

@keyframes pulse {
    0%, 100% { transform: scale(1); }
    50% { transform: scale(1.1); }
}

/* Main App */
.main-app {
    min-height: 100vh;
    background: #f8fafc;
}

/* Header */
.app-header {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
    padding: 1rem 0;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.header-content {
    max-width: 1200px;
    margin: 0 auto;
    padding: 0 2rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.logo {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-size: 1.5rem;
    font-weight: 600;
}

.logo i {
    font-size: 2rem;
}

.header-stats {
    display: flex;
    gap: 2rem;
}

.stat-item {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-weight: 500;
}

/* Camera Section */
.camera-section {
    max-width: 1200px;
    margin: 0 auto;
    padding: 2rem;
}

.camera-container {
    background: white;
    border-radius: 20px;
    box-shadow: 0 10px 40px rgba(0, 0, 0, 0.1);
    overflow: hidden;
}

/* Video Wrapper */
.video-wrapper {
    position: relative;
    background: #000;
    aspect-ratio: 16/9;
    overflow: hidden;
}

#videoElement {
    width: 100%;
    height: 100%;
    object-fit: cover;
    transition: filter 0.3s ease;
}

.camera-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    pointer-events: none;
}

/* Timer Display */
.timer-display {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 10;
}

.timer-circle {
    width: 120px;
    height: 120px;
    border: 4px solid rgba(255, 255, 255, 0.8);
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    background: rgba(0, 0, 0, 0.5);
    animation: timerPulse 1s ease-in-out;
}

.timer-circle span {
    font-size: 3rem;
    font-weight: bold;
    color: white;
}

@keyframes timerPulse {
    0% { transform: scale(0.8); opacity: 0; }
    50% { transform: scale(1.1); opacity: 1; }
    100% { transform: scale(1); opacity: 1; }
}

/* Smile Prompt */
.smile-prompt {
    position: absolute;
    bottom: 2rem;
    left: 50%;
    transform: translateX(-50%);
    background: rgba(0, 0, 0, 0.8);
    color: white;
    padding: 1rem 2rem;
    border-radius: 50px;
    animation: slideUp 0.5s ease-out;
}

.smile-content {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-size: 1.2rem;
    font-weight: 500;
}

.smile-content i {
    font-size: 1.5rem;
    color: #ffd700;
}

@keyframes slideUp {
    from { transform: translate(-50%, 100%); opacity: 0; }
    to { transform: translate(-50%, 0); opacity: 1; }
}

/* Flash Effect */
.flash-effect {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: white;
    opacity: 0;
    pointer-events: none;
}

.flash-effect.active {
    animation: flash 0.3s ease-out;
}

@keyframes flash {
    0% { opacity: 0; }
    50% { opacity: 0.8; }
    100% { opacity: 0; }
}

/* Filter Section */
.filter-section {
    padding: 2rem;
    border-bottom: 1px solid #e2e8f0;
}

.filter-section h3 {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    margin-bottom: 1rem;
    color: #334155;
    font-weight: 600;
}

.filter-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(80px, 1fr));
    gap: 1rem;
}

.filter-btn {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5rem;
    padding: 1rem 0.5rem;
    border: 2px solid transparent;
    border-radius: 12px;
    background: #f8fafc;
    cursor: pointer;
    transition: all 0.3s ease;
    font-size: 0.8rem;
    font-weight: 500;
    color: #64748b;
}

.filter-btn:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
}

.filter-btn.active {
    border-color: #667eea;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
}

.filter-preview {
    width: 40px;
    height: 40px;
    border-radius: 8px;
    background: linear-gradient(45deg, #ff6b6b, #4ecdc4, #45b7d1, #96ceb4);
    background-size: 200% 200%;
    animation: gradientShift 3s ease infinite;
}

@keyframes gradientShift {
    0% { background-position: 0% 50%; }
    50% { background-position: 100% 50%; }
    100% { background-position: 0% 50%; }
}

/* Filter Effects */
.filter-none { filter: none; }
.filter-grayscale { filter: grayscale(100%); }
.filter-sepia { filter: sepia(100%); }
.filter-vintage { filter: sepia(50%) contrast(120%) brightness(110%) saturate(80%); }
.filter-cool { filter: hue-rotate(180deg) saturate(120%) brightness(110%); }
.filter-warm { filter: hue-rotate(30deg) saturate(130%) brightness(110%); }
.filter-dramatic { filter: contrast(150%) brightness(90%) saturate(120%); }
.filter-neon { filter: hue-rotate(270deg) saturate(200%) brightness(120%) contrast(120%); }

/* Camera Controls */
.camera-controls {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 2rem;
    padding: 2rem;
}

.control-btn {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5rem;
    padding: 1rem;
    border: none;
    border-radius: 12px;
    background: #f1f5f9;
    color: #64748b;
    cursor: pointer;
    transition: all 0.3s ease;
    font-size: 0.9rem;
    font-weight: 500;
}

.control-btn:hover {
    background: #e2e8f0;
    transform: translateY(-2px);
}

.control-btn i {
    font-size: 1.5rem;
}

.capture-btn {
    width: 80px;
    height: 80px;
    border: 4px solid #667eea;
    border-radius: 50%;
    background: white;
    cursor: pointer;
    transition: all 0.3s ease;
    position: relative;
}

.capture-btn:hover {
    transform: scale(1.1);
    box-shadow: 0 8px 25px rgba(102, 126, 234, 0.3);
}

.capture-btn:active {
    transform: scale(0.95);
}

.capture-inner {
    width: 60px;
    height: 60px;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    color: white;
    font-size: 1.5rem;
    margin: 6px;
}

.capture-btn:disabled {
    opacity: 0.5;
    cursor: not-allowed;
    transform: none;
}

/* Gallery Section */
.gallery-section {
    max-width: 1200px;
    margin: 0 auto;
    padding: 2rem;
}

.gallery-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 2rem;
}

.gallery-header h2 {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
}

.photo-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
    gap: 1.5rem;
    margin-bottom: 3rem;
}

.empty-gallery {
    grid-column: 1 / -1;
    text-align: center;
    padding: 4rem 2rem;
    color: #94a3b8;
}

.empty-gallery i {
    font-size: 4rem;
    margin-bottom: 1rem;
    opacity: 0.5;
}

.empty-gallery p {
    font-size: 1.2rem;
    font-weight: 500;
    margin-bottom: 0.5rem;
}

.photo-item {
    background: white;
    border-radius: 16px;
    overflow: hidden;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
    cursor: pointer;
}

.photo-item:hover {
    transform: translateY(-4px);
    box-shadow: 0 8px 30px rgba(0, 0, 0, 0.15);
}

.photo-item img {
    width: 100%;
    height: 200px;
    object-fit: cover;
}

.photo-info {
    padding: 1rem;
}

.photo-meta {
    display: flex;
    justify-content: space-between;
    align-items: center;
    font-size: 0.9rem;
    color: #64748b;
}

.filter-tag {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
    padding: 0.25rem 0.75rem;
    border-radius: 20px;
    font-size: 0.8rem;
    font-weight: 500;
}

/* Buttons */
.btn-primary, .btn-secondary, .btn-danger {
    display: inline-flex;
    align-items: center;
    gap: 0.5rem;
    padding: 0.75rem 1.5rem;
    border: none;
    border-radius: 12px;
    font-weight: 500;
    cursor: pointer;
    transition: all 0.3s ease;
    text-decoration: none;
}

.btn-primary {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
}

.btn-primary:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 15px rgba(102, 126, 234, 0.3);
}

.btn-secondary {
    background: #f1f5f9;
    color: #64748b;
}

.btn-secondary:hover {
    background: #e2e8f0;
}

.btn-danger {
    background: #ef4444;
    color: white;
}

.btn-danger:hover {
    background: #dc2626;
}

.btn-primary.disabled {
    background: #cbd5e1;
    color: #94a3b8;
    cursor: not-allowed;
    transform: none;
}

.btn-primary.disabled:hover {
    transform: none;
    box-shadow: none;
}

/* Collage Section */
.collage-section {
    text-align: center;
    padding: 2rem;
    background: white;
    border-radius: 20px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.collage-result h3 {
    margin-bottom: 1.5rem;
    color: #334155;
    font-weight: 600;
}

.collage-container {
    margin-bottom: 1.5rem;
}

#collageCanvas {
    max-width: 100%;
    border-radius: 12px;
    box-shadow: 0 8px 30px rgba(0, 0, 0, 0.15);
}

.collage-actions {
    display: flex;
    justify-content: center;
    gap: 1rem;
    flex-wrap: wrap;
}

/* Modal Styles */
.modal {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.8);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 1000;
    backdrop-filter: blur(4px);
}

.modal-content {
    background: white;
    border-radius: 20px;
    max-width: 500px;
    width: 90%;
    max-height: 90vh;
    overflow-y: auto;
    box-shadow: 0 20px 60px rgba(0, 0, 0, 0.3);
}

.photo-modal .modal-content {
    max-width: 800px;
}

.modal-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1.5rem;
    border-bottom: 1px solid #e2e8f0;
}

.modal-header h3 {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
}

.close-btn {
    width: 40px;
    height: 40px;
    border: none;
    border-radius: 50%;
    background: #f1f5f9;
    color: #64748b;
    cursor: pointer;
    transition: all 0.3s ease;
}

.close-btn:hover {
    background: #e2e8f0;
}

.modal-body {
    padding: 1.5rem;
}

/* Settings */
.setting-group {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1rem 0;
    border-bottom: 1px solid #f1f5f9;
}

.setting-group:last-child {
    border-bottom: none;
}

.setting-group label {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-weight: 500;
    color: #334155;
}

.setting-group select {
    padding: 0.5rem;
    border: 1px solid #d1d5db;
    border-radius: 8px;
    background: white;
    color: #374151;
}

/* Toggle Switch */
.toggle-switch {
    position: relative;
    width: 50px;
    height: 24px;
}

.toggle-switch input {
    opacity: 0;
    width: 0;
    height: 0;
}

.slider {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #cbd5e1;
    transition: 0.3s;
    border-radius: 24px;
}

.slider:before {
    position: absolute;
    content: "";
    height: 18px;
    width: 18px;
    left: 3px;
    bottom: 3px;
    background-color: white;
    transition: 0.3s;
    border-radius: 50%;
}

input:checked + .slider {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

input:checked + .slider:before {
    transform: translateX(26px);
}

/* Photo Actions */
.photo-actions {
    display: flex;
    justify-content: center;
    gap: 1rem;
    margin-top: 1.5rem;
}

#previewImage {
    width: 100%;
    border-radius: 12px;
}

/* Responsive Design */
@media (max-width: 768px) {
    .header-content {
        padding: 0 1rem;
    }
    
    .camera-section,
    .gallery-section {
        padding: 1rem;
    }
    
    .filter-grid {
        grid-template-columns: repeat(4, 1fr);
    }
    
    .camera-controls {
        gap: 1rem;
    }
    
    .capture-btn {
        width: 70px;
        height: 70px;
    }
    
    .capture-inner {
        width: 50px;
        height: 50px;
        margin: 8px;
    }
    
    .photo-grid {
        grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
        gap: 1rem;
    }
    
    .gallery-header {
        flex-direction: column;
        gap: 1rem;
        align-items: stretch;
    }
    
    .collage-actions {
        flex-direction: column;
    }
    
    .modal-content {
        margin: 1rem;
        width: calc(100% - 2rem);
    }
}

@media (max-width: 480px) {
    .logo span {
        display: none;
    }
    
    .filter-grid {
        grid-template-columns: repeat(3, 1fr);
    }
    
    .camera-controls {
        flex-direction: column;
        gap: 1.5rem;
    }
    
    .control-btn {
        flex-direction: row;
        padding: 0.75rem 1.5rem;
    }
}