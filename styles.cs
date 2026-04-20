:root {
  --bg: #f5f7fb;
  --bg-accent: #fff4e5;
  --surface: rgba(255, 255, 255, 0.82);
  --surface-strong: #ffffff;
  --text: #132238;
  --muted: #60708a;
  --line: rgba(19, 34, 56, 0.12);
  --line-strong: rgba(19, 34, 56, 0.2);
  --brand: #246bff;
  --brand-soft: #dfe9ff;
  --mint: #b9f4dc;
  --peach: #ffd5b3;
  --shadow: 0 24px 60px rgba(36, 57, 89, 0.12);
  --header-height: 82px;
  --radius-xl: 32px;
  --radius-lg: 24px;
}

html[data-theme="dark"] {
  --bg: #07111d;
  --bg-accent: #0f1c2e;
  --surface: rgba(13, 22, 38, 0.82);
  --surface-strong: #101b2f;
  --text: #eef4ff;
  --muted: #98a9c7;
  --line: rgba(170, 190, 230, 0.14);
  --line-strong: rgba(170, 190, 230, 0.24);
  --brand: #72b1ff;
  --brand-soft: rgba(114, 177, 255, 0.18);
  --shadow: 0 24px 60px rgba(0, 0, 0, 0.35);
}

* {
  box-sizing: border-box;
}

html {
  scroll-behavior: smooth;
}

body {
  margin: 0;
  min-height: 100vh;
  font-family: "Plus Jakarta Sans", sans-serif;
  color: var(--text);
  background:
    radial-gradient(circle at top left, rgba(36, 107, 255, 0.09), transparent 26%),
    radial-gradient(circle at 80% 0%, rgba(255, 213, 179, 0.65), transparent 24%),
    linear-gradient(180deg, #f8fbff 0%, #f4f7fb 52%, #eef3fa 100%);
  overflow-x: hidden;
  transition:
    background 300ms ease,
    color 300ms ease;
}

html[data-theme="dark"] body {
  background:
    radial-gradient(circle at top left, rgba(114, 177, 255, 0.12), transparent 26%),
    radial-gradient(circle at 80% 0%, rgba(105, 149, 230, 0.18), transparent 24%),
    linear-gradient(180deg, #07111d 0%, #081423 52%, #09192d 100%);
}

body.cursor-active {
  cursor: none;
}

section[id] {
  scroll-margin-top: calc(var(--header-height) + 22px);
}

.bg-blob,
.bg-grid,
.tool-cloud,
.cursor-glow,
.cursor-dot {
  position: fixed;
  pointer-events: none;
}

.bg-blob,
.bg-grid,
.tool-cloud {
  z-index: -1;
}

.cursor-glow,
.cursor-dot {
  top: 0;
  left: 0;
  opacity: 0;
  transition: opacity 180ms ease;
}

.cursor-glow {
  width: 240px;
  height: 240px;
  margin-left: -120px;
  margin-top: -120px;
  border-radius: 50%;
  background: radial-gradient(circle, rgba(36, 107, 255, 0.16), rgba(36, 107, 255, 0.05) 42%, transparent 72%);
  z-index: 40;
  mix-blend-mode: multiply;
}

.cursor-dot {
  width: 12px;
  height: 12px;
  margin-left: -6px;
  margin-top: -6px;
  border-radius: 50%;
  background: linear-gradient(135deg, var(--brand), #7ea8ff);
  box-shadow: 0 0 0 8px rgba(36, 107, 255, 0.12);
  z-index: 41;
}

body.cursor-active .cursor-glow,
body.cursor-active .cursor-dot {
  opacity: 1;
}

.bg-blob {
  width: 320px;
  height: 320px;
  border-radius: 50%;
  filter: blur(40px);
  opacity: 0.55;
}

.blob-one {
  top: 120px;
  left: -80px;
  background: rgba(36, 107, 255, 0.18);
}

.blob-two {
  right: -80px;
  top: 420px;
  background: rgba(255, 170, 112, 0.2);
}

.bg-grid {
  inset: 0;
  background-image:
    linear-gradient(rgba(19, 34, 56, 0.035) 1px, transparent 1px),
    linear-gradient(90deg, rgba(19, 34, 56, 0.035) 1px, transparent 1px);
  background-size: 48px 48px;
  mask-image: radial-gradient(circle at center, black 35%, transparent 85%);
  opacity: 0.45;
}

.bg-grid::after {
  content: "";
  position: absolute;
  inset: 0;
  background: linear-gradient(180deg, rgba(248, 251, 255, 0.1), rgba(248, 251, 255, 0.7));
}

.tool-cloud {
  inset: 0;
  overflow: hidden;
}

.floating-tool {
  position: absolute;
  width: 48px;
  height: 48px;
  opacity: 0.15;
  filter: saturate(0.9);
  animation: toolFloat 10s ease-in-out infinite;
}

.floating-tool-text {
  display: grid;
  place-items: center;
  width: 84px;
  height: 42px;
  border-radius: 999px;
  border: 1px solid rgba(19, 34, 56, 0.1);
  background: rgba(255, 255, 255, 0.5);
  color: var(--muted);
  font-family: "IBM Plex Mono", monospace;
  font-size: 0.76rem;
  letter-spacing: 0.06em;
  text-transform: uppercase;
}

.tool-docker { top: 10%; left: 6%; animation-delay: 0s; }
.tool-kubernetes { top: 22%; right: 8%; animation-delay: 1s; }
.tool-grafana { top: 38%; left: 4%; animation-delay: 2s; }
.tool-aws { top: 14%; right: 22%; width: 110px; height: auto; animation-delay: 3s; }
.tool-jenkins { top: 56%; right: 10%; animation-delay: 4s; }
.tool-github { top: 72%; left: 10%; animation-delay: 1.5s; }
.tool-gcp { top: 64%; right: 22%; animation-delay: 2.5s; }
.tool-kafka { top: 82%; left: 30%; animation-delay: 3.5s; }
.tool-ansible { top: 28%; left: 26%; animation-delay: 4.5s; }
.tool-claude { top: 78%; right: 6%; animation-delay: 5s; }

a,
button {
  color: inherit;
  font: inherit;
}

button {
  border: 0;
}

.site-header {
  position: sticky;
  top: 0;
  z-index: 20;
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 24px;
  padding: 18px 28px;
  min-height: var(--header-height);
  background: rgba(245, 247, 251, 0.78);
  backdrop-filter: blur(16px);
  border-bottom: 1px solid rgba(19, 34, 56, 0.06);
}

html[data-theme="dark"] .site-header {
  background: rgba(7, 17, 29, 0.74);
  border-bottom-color: rgba(170, 190, 230, 0.08);
}

.brand,
.brand-copy,
.site-nav,
.trust-row,
.hero-actions,
.stack-tags,
.hero-chips,
.crew-tags,
.contact-links,
.theme-toggle {
  display: flex;
}

.brand {
  align-items: center;
  gap: 14px;
  text-decoration: none;
}

.brand-mark {
  display: grid;
  place-items: center;
  width: 46px;
  height: 46px;
  border-radius: 16px;
  background: linear-gradient(135deg, var(--brand), #69a1ff);
  color: white;
  font-weight: 800;
  box-shadow: 0 14px 28px rgba(36, 107, 255, 0.24);
}

.brand-copy {
  flex-direction: column;
  gap: 2px;
}

.brand-copy strong {
  font-size: 0.95rem;
}

.brand-copy span,
.site-nav a,
.eyebrow,
.stack-kicker,
.info-label,
.panel-label,
.workflow-index {
  color: var(--muted);
}

.site-nav {
  gap: 22px;
  align-items: center;
}

.site-nav a {
  text-decoration: none;
  font-size: 0.94rem;
}

.theme-toggle {
  align-items: center;
  gap: 10px;
  padding: 10px 12px;
  border-radius: 999px;
  border: 1px solid var(--line);
  background: rgba(255, 255, 255, 0.62);
  cursor: pointer;
}

.theme-toggle-track {
  position: relative;
  width: 46px;
  height: 24px;
  border-radius: 999px;
  background: rgba(36, 107, 255, 0.18);
}

.theme-toggle-thumb {
  position: absolute;
  top: 3px;
  left: 3px;
  width: 18px;
  height: 18px;
  border-radius: 50%;
  background: var(--brand);
  transition: transform 220ms ease;
}

.theme-toggle-label {
  font-size: 0.84rem;
  color: var(--muted);
}

html[data-theme="dark"] .theme-toggle-thumb {
  transform: translateX(22px);
}

main {
  width: min(1200px, calc(100% - 32px));
  margin: 0 auto;
  padding-bottom: 80px;
}

.hero,
.section-block {
  padding: 42px 0;
}

.section-block {
  position: relative;
}

.section-block::after {
  content: "";
  position: absolute;
  left: 0;
  right: 0;
  bottom: -6px;
  height: 1px;
  background: linear-gradient(90deg, transparent, var(--line), transparent);
  opacity: 0.9;
}

.hero {
  min-height: calc(100svh - var(--header-height));
  display: grid;
  grid-template-columns: minmax(0, 1fr) minmax(320px, 0.92fr);
  gap: 38px;
  align-items: center;
}

.eyebrow,
.stack-kicker,
.info-label,
.panel-label,
.workflow-index {
  margin: 0;
  font-family: "IBM Plex Mono", monospace;
  font-size: 0.74rem;
  text-transform: uppercase;
  letter-spacing: 0.16em;
}

.hero h1,
.section-heading h2,
.contact-panel h2 {
  margin: 0;
  line-height: 0.98;
  letter-spacing: -0.045em;
}

.hero h1 {
  max-width: 11ch;
  font-size: clamp(3.2rem, 8vw, 6.2rem);
}

.hero-text,
.section-summary,
.info-card p,
.stack-item p,
.stack-panel p,
.crew-card p,
.workflow-card p {
  color: var(--muted);
  line-height: 1.7;
}

.hero-text {
  max-width: 38rem;
  margin: 20px 0 0;
  font-size: 1.06rem;
}

.hero-actions {
  flex-wrap: wrap;
  gap: 14px;
  margin-top: 28px;
}

.hero-chips {
  flex-wrap: wrap;
  gap: 10px;
  margin-top: 18px;
}

.hero-chips span,
.crew-tags span,
.contact-links a,
.scene-badge,
.impact-label {
  font-family: "IBM Plex Mono", monospace;
  font-size: 0.74rem;
  letter-spacing: 0.04em;
}

.hero-chips span,
.crew-tags span {
  padding: 10px 12px;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.72);
  border: 1px solid var(--line);
  color: #35507a;
}

.primary-link,
.secondary-link {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  min-height: 52px;
  padding: 0 20px;
  border-radius: 999px;
  text-decoration: none;
  transition:
    transform 180ms ease,
    box-shadow 180ms ease,
    border-color 180ms ease,
    background-color 180ms ease;
}

.primary-link {
  background: linear-gradient(135deg, var(--brand), #5e92ff);
  color: white;
  box-shadow: 0 16px 36px rgba(36, 107, 255, 0.24);
}

.secondary-link {
  border: 1px solid var(--line-strong);
  background: rgba(255, 255, 255, 0.58);
}

.primary-link:hover,
.secondary-link:hover,
.site-nav a:hover {
  transform: translateY(-2px);
}

.trust-row {
  flex-wrap: wrap;
  gap: 14px;
  margin-top: 26px;
}

.trust-row div {
  min-width: 140px;
  padding: 16px 18px;
  border: 1px solid var(--line);
  border-radius: 18px;
  background: rgba(255, 255, 255, 0.65);
  box-shadow: var(--shadow);
}

.trust-row strong {
  display: block;
  font-size: 1.05rem;
}

.trust-row span {
  display: block;
  margin-top: 6px;
  color: var(--muted);
  font-size: 0.92rem;
}

.hero-stage {
  display: grid;
  align-items: center;
}

.scene-shell {
  position: relative;
  min-height: 560px;
  border-radius: 40px;
  padding: 28px;
  background:
    radial-gradient(circle at 30% 20%, rgba(36, 107, 255, 0.12), transparent 20%),
    linear-gradient(180deg, rgba(255, 255, 255, 0.72), rgba(255, 255, 255, 0.45));
  border: 1px solid rgba(255, 255, 255, 0.72);
  box-shadow: var(--shadow);
  overflow: hidden;
  transform-style: preserve-3d;
  transition: transform 220ms ease;
}

html[data-theme="dark"] .scene-shell,
html[data-theme="dark"] .impact-card,
html[data-theme="dark"] .recruiter-card,
html[data-theme="dark"] .project-card,
html[data-theme="dark"] .intro-panel,
html[data-theme="dark"] .contact-panel,
html[data-theme="dark"] .stack-panel,
html[data-theme="dark"] .info-card,
html[data-theme="dark"] .crew-card,
html[data-theme="dark"] .workflow-card,
html[data-theme="dark"] .stack-item,
html[data-theme="dark"] .recruiter-panel {
  background: var(--surface);
  border-color: var(--line);
  box-shadow: var(--shadow);
}

.hero-illustration {
  position: absolute;
  left: 50%;
  bottom: 4px;
  width: 370px;
  height: 354px;
  transform: translateX(-50%);
  filter: drop-shadow(0 20px 30px rgba(36, 57, 89, 0.14));
  animation: bobSvg 4.5s ease-in-out infinite;
}

.scene-card {
  position: absolute;
  padding: 20px;
  border-radius: 24px;
  background: rgba(255, 255, 255, 0.9);
  border: 1px solid rgba(19, 34, 56, 0.08);
  box-shadow: 0 18px 40px rgba(36, 57, 89, 0.1);
}

.scene-card-main {
  top: 24px;
  left: 24px;
  width: min(320px, 100%);
}

.scene-card-floating {
  right: 28px;
  bottom: 40px;
  width: 180px;
  animation: drift 5.5s ease-in-out infinite;
}

.scene-card-side {
  width: 170px;
  font-size: 0.92rem;
}

.scene-card-left {
  left: 18px;
  bottom: 102px;
}

.scene-card-right {
  right: 18px;
  top: 154px;
}

.scene-card strong {
  display: block;
  margin-top: 8px;
  font-size: 1.35rem;
  line-height: 1.1;
}

.scene-card p,
.scene-card ul {
  margin: 12px 0 0;
  color: var(--muted);
  line-height: 1.6;
}

.scene-card ul {
  padding-left: 18px;
}

.scene-label {
  font-family: "IBM Plex Mono", monospace;
  font-size: 0.72rem;
  letter-spacing: 0.15em;
  text-transform: uppercase;
  color: var(--muted);
}

.scene-orbit,
.scene-dot,
.scene-badge {
  position: absolute;
}

.scene-dot {
  border-radius: 50%;
}

.scene-orbit {
  border: 1px dashed rgba(36, 107, 255, 0.22);
  animation: spin 24s linear infinite;
}

.scene-line {
  position: absolute;
  height: 1px;
  background: linear-gradient(90deg, transparent, rgba(36, 107, 255, 0.8), transparent);
  transform-origin: left center;
}

.line-one {
  left: 98px;
  top: 238px;
  width: 82px;
  transform: rotate(-16deg);
}

.line-two {
  right: 104px;
  top: 254px;
  width: 98px;
  transform: rotate(18deg);
}

.orbit-one {
  inset: 110px 70px 80px 70px;
}

.orbit-two {
  inset: 150px 110px 120px 110px;
  animation-direction: reverse;
  animation-duration: 18s;
}

.scene-badge {
  padding: 10px 14px;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.84);
  border: 1px solid rgba(19, 34, 56, 0.08);
  box-shadow: 0 12px 24px rgba(36, 57, 89, 0.08);
  color: #35507a;
}

.badge-one {
  top: 104px;
  right: 42px;
}

.badge-two {
  left: 34px;
  bottom: 56px;
}

.badge-three {
  top: 78px;
  left: 170px;
}

.scene-dot {
  width: 16px;
  height: 16px;
  background: var(--brand);
  box-shadow: 0 0 0 8px rgba(36, 107, 255, 0.12);
}

.dot-one {
  top: 132px;
  right: 100px;
}

.dot-two {
  left: 72px;
  bottom: 154px;
  background: #43c897;
  box-shadow: 0 0 0 8px rgba(67, 200, 151, 0.14);
}

.dot-three {
  right: 142px;
  bottom: 94px;
  background: #ff9a4d;
  box-shadow: 0 0 0 8px rgba(255, 154, 77, 0.14);
}

.section-block {
  display: grid;
  gap: 28px;
}

.impact-strip {
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 18px;
}

.impact-card {
  padding: 22px;
  border-radius: 24px;
  background: rgba(255, 255, 255, 0.76);
  border: 1px solid var(--line);
  box-shadow: var(--shadow);
}

.impact-card,
.recruiter-card,
.project-card,
.info-card,
.crew-card,
.workflow-card,
.stack-item {
  position: relative;
  overflow: hidden;
}

.impact-card::before,
.recruiter-card::before,
.project-card::before,
.info-card::before,
.crew-card::before,
.workflow-card::before,
.stack-item::before {
  content: "";
  position: absolute;
  inset: 0;
  background: radial-gradient(circle at var(--mx, 50%) var(--my, 50%), rgba(36, 107, 255, 0.12), transparent 42%);
  opacity: 0;
  transition: opacity 180ms ease;
  pointer-events: none;
}

.impact-card:hover::before,
.recruiter-card:hover::before,
.project-card:hover::before,
.info-card:hover::before,
.crew-card:hover::before,
.workflow-card:hover::before,
.stack-item:hover::before {
  opacity: 1;
}

.impact-card strong {
  display: block;
  margin-top: 10px;
  font-size: 1.18rem;
  line-height: 1.2;
}

.impact-card p {
  margin: 10px 0 0;
  color: var(--muted);
  line-height: 1.7;
}

.recruiter-panel {
  padding: 28px;
  border-radius: var(--radius-xl);
  border: 1px solid var(--line);
  background: linear-gradient(180deg, rgba(255, 255, 255, 0.86), rgba(255, 255, 255, 0.74));
  box-shadow: var(--shadow);
}

.recruiter-grid,
.projects-grid {
  display: grid;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 18px;
}

.recruiter-card,
.project-card {
  padding: 24px;
  border-radius: 24px;
  border: 1px solid var(--line);
  background: rgba(255, 255, 255, 0.72);
  box-shadow: var(--shadow);
}

.recruiter-card strong,
.project-card h3 {
  display: block;
  margin-top: 10px;
  font-size: 1.24rem;
  line-height: 1.2;
}

.recruiter-card p,
.project-card p {
  margin: 10px 0 0;
  color: var(--muted);
  line-height: 1.7;
}

.recruiter-actions .hero-actions {
  margin-top: 16px;
}

.project-card a {
  display: inline-flex;
  margin-top: 16px;
  color: #2956b8;
  text-decoration: none;
  font-weight: 700;
}

.project-card:hover,
.recruiter-card:hover,
.info-card:hover,
.impact-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 22px 44px rgba(36, 57, 89, 0.14);
}

.section-heading {
  display: grid;
  grid-template-columns: minmax(0, 1fr) minmax(260px, 400px);
  gap: 22px;
  align-items: end;
}

.section-heading h2,
.contact-panel h2 {
  max-width: 12ch;
  font-size: clamp(2.2rem, 5vw, 4rem);
}

.section-summary {
  margin: 0;
}

.intro-panel,
.contact-panel,
.stack-panel,
.info-card,
.crew-card,
.workflow-card {
  border: 1px solid var(--line);
  background: var(--surface);
  box-shadow: var(--shadow);
  backdrop-filter: blur(14px);
}

.intro-panel,
.contact-panel {
  padding: 28px;
  border-radius: var(--radius-xl);
}

.intro-grid,
.crew-grid,
.workflow-grid {
  display: grid;
  gap: 18px;
}

.intro-grid {
  grid-template-columns: repeat(3, minmax(0, 1fr));
}

.info-card,
.crew-card,
.workflow-card {
  padding: 24px;
  border-radius: var(--radius-lg);
}

.info-card h3,
.stack-panel h3,
.crew-card h3,
.workflow-card h3 {
  margin: 10px 0 12px;
  font-size: 1.4rem;
  line-height: 1.1;
}

.stack-explorer {
  display: grid;
  grid-template-columns: minmax(0, 0.95fr) minmax(320px, 0.9fr);
  gap: 20px;
}

.stack-list {
  display: grid;
  gap: 14px;
}

.stack-item {
  display: grid;
  grid-template-columns: 56px 1fr;
  gap: 16px;
  align-items: start;
  width: 100%;
  padding: 20px;
  border-radius: 22px;
  border: 1px solid var(--line);
  background: rgba(255, 255, 255, 0.76);
  box-shadow: var(--shadow);
  cursor: pointer;
  text-align: left;
  transition:
    transform 180ms ease,
    border-color 180ms ease,
    box-shadow 180ms ease,
    background-color 180ms ease;
}

.stack-item strong {
  display: block;
  font-size: 1.15rem;
}

.stack-item p {
  margin: 8px 0 0;
}

.stack-item:hover,
.stack-item:focus-visible,
.stack-item.active {
  transform: translateY(-4px);
  border-color: rgba(36, 107, 255, 0.28);
  background: white;
  box-shadow: 0 20px 40px rgba(36, 107, 255, 0.1);
}

.stack-panel {
  position: sticky;
  top: calc(var(--header-height) + 16px);
  padding: 26px;
  border-radius: 28px;
}

.stack-panel p {
  margin: 0;
}

.stack-tags {
  flex-wrap: wrap;
  gap: 10px;
  margin: 18px 0;
}

.stack-tags span {
  padding: 10px 14px;
  border-radius: 999px;
  background: var(--brand-soft);
  color: #264780;
  font-size: 0.84rem;
  font-weight: 600;
}

.stack-note {
  padding-top: 16px;
  border-top: 1px solid var(--line);
  color: var(--muted);
  line-height: 1.7;
}

.crew-grid {
  grid-template-columns: repeat(3, minmax(0, 1fr));
}

.crew-avatar {
  width: 92px;
  height: 92px;
  margin-bottom: 18px;
}

.crew-card {
  transition:
    transform 180ms ease,
    box-shadow 180ms ease,
    border-color 180ms ease;
}

.crew-card:hover {
  transform: translateY(-6px);
  box-shadow: 0 22px 44px rgba(36, 57, 89, 0.14);
}

.crew-tags {
  flex-wrap: wrap;
  gap: 8px;
  margin-top: 16px;
}

.workflow-grid {
  grid-template-columns: repeat(4, minmax(0, 1fr));
}

.workflow-index {
  display: inline-block;
  margin-bottom: 14px;
}

.workflow-story {
  display: grid;
  gap: 18px;
}

.workflow-progress {
  position: relative;
  height: 8px;
  border-radius: 999px;
  background: rgba(36, 107, 255, 0.1);
  overflow: hidden;
}

.workflow-progress-bar {
  width: 25%;
  height: 100%;
  border-radius: inherit;
  background: linear-gradient(90deg, var(--brand), #7ea8ff);
  transition: width 260ms ease;
}

.workflow-card {
  transition:
    transform 220ms ease,
    border-color 220ms ease,
    box-shadow 220ms ease,
    background-color 220ms ease;
}

.workflow-card.is-active {
  transform: translateY(-6px);
  border-color: rgba(36, 107, 255, 0.24);
  background: white;
  box-shadow: 0 22px 44px rgba(36, 107, 255, 0.12);
}

.contact-links {
  flex-wrap: wrap;
  gap: 14px;
  margin-top: 18px;
}

.contact-links a {
  text-decoration: none;
  color: #35507a;
}

.site-footer {
  padding: 12px 0 0;
  color: var(--muted);
  text-align: center;
}

.reveal {
  opacity: 0;
  transform: translateY(22px);
  transition:
    opacity 600ms ease,
    transform 600ms ease;
}

.reveal.is-visible {
  opacity: 1;
  transform: translateY(0);
}

@keyframes bob {
  0%,
  100% {
    transform: translateY(0);
  }

  50% {
    transform: translateY(-10px);
  }
}

@keyframes bobSvg {
  0%,
  100% {
    transform: translateX(-50%) translateY(0);
  }

  50% {
    transform: translateX(-50%) translateY(-10px);
  }
}

@keyframes drift {
  0%,
  100% {
    transform: translateY(0);
  }

  50% {
    transform: translateY(-10px);
  }
}

@keyframes spin {
  from {
    transform: rotate(0deg);
  }

  to {
    transform: rotate(360deg);
  }
}

@keyframes toolFloat {
  0%,
  100% {
    transform: translate3d(0, 0, 0) rotate(0deg);
  }

  50% {
    transform: translate3d(0, -12px, 0) rotate(4deg);
  }
}

@media (prefers-reduced-motion: reduce) {
  html {
    scroll-behavior: auto;
  }

  .reveal,
  .primary-link,
  .secondary-link,
  .stack-item,
  .site-nav a,
  .crew-card,
  .scene-shell,
  .impact-card,
  .recruiter-card,
  .project-card,
  .info-card,
  .workflow-card {
    transition: none;
  }

  .reveal {
    opacity: 1;
    transform: none;
  }

  .hero-illustration,
  .scene-card-floating,
  .scene-orbit {
    animation: none;
  }
}

@media (hover: none), (pointer: coarse) {
  .cursor-glow,
  .cursor-dot {
    display: none;
  }

  body.cursor-active {
    cursor: auto;
  }
}

@media (max-width: 1080px) {
  .hero,
  .section-heading,
  .intro-grid,
  .crew-grid,
  .workflow-grid,
  .stack-explorer,
  .impact-strip,
  .recruiter-grid,
  .projects-grid {
    grid-template-columns: 1fr;
  }

  .hero {
    min-height: auto;
    padding-top: 28px;
  }

  .stack-panel {
    position: relative;
    top: 0;
  }
}

@media (max-width: 760px) {
  :root {
    --header-height: 120px;
  }

  .site-header {
    flex-direction: column;
    align-items: flex-start;
    padding: 16px 18px;
  }

  .site-nav {
    flex-wrap: wrap;
    gap: 14px 18px;
  }

  main {
    width: min(100% - 24px, 1200px);
  }

  .hero h1 {
    font-size: clamp(2.7rem, 15vw, 4.4rem);
  }

  .scene-shell {
    min-height: 480px;
  }

  .badge-one,
  .badge-two,
  .badge-three,
  .scene-card-right,
  .scene-card-left,
  .line-one,
  .line-two {
    display: none;
  }

  .scene-card-main {
    width: calc(100% - 48px);
  }

  .tool-aws,
  .tool-kafka,
  .tool-claude,
  .tool-ansible {
    display: none;
  }

  .scene-card-floating {
    right: 18px;
    bottom: 18px;
    width: 148px;
  }

  .hero-illustration {
    width: 290px;
    height: 278px;
    bottom: 22px;
  }

  .intro-panel,
  .contact-panel,
  .recruiter-panel,
  .info-card,
  .crew-card,
  .workflow-card,
  .recruiter-card,
  .project-card,
  .stack-panel,
  .stack-item {
    padding: 20px;
  }
}
